using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LegendOfZelda.SimpleEnemyStateMachine;

namespace LegendOfZelda
{
    public enum CollisionLayer
    {
        Player, Enemy, Wall, PlayerWeapon, EnemyWeapon, Item, OuterWall
    }

    public struct CollisionInfo
    {
        public CollisionInfo(IRectCollider MyCollider, IRectCollider CollidedWith, Direction EstimatedDirection, Rectangle OverlapRectangle)
        {
            this.MyCollider = MyCollider;
            this.CollidedWith = CollidedWith;
            this.EstimatedDirection = EstimatedDirection;
            this.OverlapRectangle = OverlapRectangle;
        }

        public IRectCollider MyCollider { get; private set; }
        public IRectCollider CollidedWith { get; private set; }
        public Direction EstimatedDirection { get; private set; }
        public Rectangle OverlapRectangle { get; private set; }

        public Boolean wasCollision
        {
            get
            {
                return !OverlapRectangle.IsEmpty;
            }
        }
    }

    public class CollisionManager : IUpdateable
    {
        public static CollisionManager instance { get; private set;}
        private Game1 game;
        private Dictionary<CollisionLayer, List<IRectCollider>> rectColliders;
        private Dictionary<CollisionLayer, List<CollisionLayer>> legalCollisions;
        
        //This map holds all of the collisions such that they can all be sent out at once
        private Dictionary<ICollidable, List<CollisionInfo>> collisionBuffer;

        public CollisionManager() {
            instance = this;
            game = Game1.getInstance();
            
            rectColliders = new Dictionary<CollisionLayer, List<IRectCollider>>();
            foreach(CollisionLayer collisionLayer in Enum.GetValues(typeof(CollisionLayer)))
            {
                rectColliders.Add(collisionLayer, new List<IRectCollider>());
            }

            legalCollisions = new Dictionary<CollisionLayer, List<CollisionLayer>>();
            legalCollisions.Add(CollisionLayer.Player, new List<CollisionLayer>{ CollisionLayer.Enemy, CollisionLayer.Wall, CollisionLayer.OuterWall, CollisionLayer.EnemyWeapon, CollisionLayer.Item, CollisionLayer.PlayerWeapon });
            legalCollisions.Add(CollisionLayer.Enemy, new List<CollisionLayer> { CollisionLayer.Wall, CollisionLayer.OuterWall, CollisionLayer.PlayerWeapon, CollisionLayer.EnemyWeapon });
            legalCollisions.Add(CollisionLayer.PlayerWeapon, new List<CollisionLayer> { CollisionLayer.OuterWall });
            legalCollisions.Add(CollisionLayer.EnemyWeapon, new List<CollisionLayer> { CollisionLayer.OuterWall });
            legalCollisions.Add(CollisionLayer.Wall, new List<CollisionLayer>());
            legalCollisions.Add(CollisionLayer.OuterWall, new List<CollisionLayer>());
            legalCollisions.Add(CollisionLayer.Item, new List<CollisionLayer>());

            collisionBuffer = new Dictionary<ICollidable, List<CollisionInfo>>();
        }

        //Returns false on error
        public bool AddRectCollider(IRectCollider collider)
        {
            if(!rectColliders.TryGetValue(collider.Layer, out List<IRectCollider> colliderList)) return false;
            if(colliderList.Contains(collider)) { return false; }

            colliderList.Add(collider);
            return true;
        }

        //Returns false on error
        public bool RemoveRectCollider(IRectCollider collider)
        {
            if (!rectColliders.TryGetValue(collider.Layer, out List<IRectCollider> colliderList)) return false;
            if (!colliderList.Contains(collider)) { return false; }

            colliderList.Remove(collider);
            return true;
        }

        public void Update(GameTime gameTime)
        {
            /*
             * This looks like several orders of looping but it is actually testing much fewer collisions than if 
             * we were to loop once over every collider for every collider. The foreaches have O(1) entries.
             */
            foreach (KeyValuePair<CollisionLayer, List<IRectCollider>> rectColliderList in rectColliders)
            {
                CollisionLayer layer = rectColliderList.Key;
                for(int i = rectColliderList.Value.Count - 1; i >= 0; i--)
                {
                    IRectCollider rectCollider = rectColliderList.Value[i];
                    foreach(CollisionLayer targetLayer in legalCollisions[layer])
                    {
                        for(int j = rectColliders[targetLayer].Count - 1; j >= 0; j--)
                        {
                            IRectCollider targetCollider = rectColliders[targetLayer][j];

                            TestCollision(rectCollider, targetCollider);
                        }
                    }
                }
            }

            SendAllCollisions();
        }

        private void TestCollision(IRectCollider rectCollider1, IRectCollider rectCollider2)
        {
            //Test if collision ocurred
            Rectangle overlapRectangle = Rectangle.Intersect(rectCollider1.Rect, rectCollider2.Rect);

            //If not return empty collision
            if (overlapRectangle.IsEmpty) return;

            //Determine collision direction
            Direction collisionDir1, collisionDir2;
            if(overlapRectangle.Width > overlapRectangle.Height)
            {
                if(rectCollider1.Rect.Top < rectCollider2.Rect.Top)
                {
                    collisionDir1 = Direction.down;
                    collisionDir2 = Direction.up;
                }
                else
                {
                    collisionDir1 = Direction.up;
                    collisionDir2 = Direction.down;
                }
            }
            else
            {
                if (rectCollider1.Rect.Right > rectCollider2.Rect.Right)
                {
                    collisionDir1 = Direction.left;
                    collisionDir2 = Direction.right;
                }
                else
                {
                    collisionDir1 = Direction.right;
                    collisionDir2 = Direction.left;
                }
            }

            //Add collision messages to buffer
            AddCollisionToBuffer(rectCollider1.Collidable, new CollisionInfo(rectCollider1, rectCollider2, collisionDir1, overlapRectangle));
            AddCollisionToBuffer(rectCollider2.Collidable, new CollisionInfo(rectCollider2, rectCollider1, collisionDir2, overlapRectangle));
        }

        private void AddCollisionToBuffer(ICollidable collidable, CollisionInfo collisionInfo)
        {
            if (!collisionBuffer.ContainsKey(collidable))
            {
                collisionBuffer.Add(collidable, new List<CollisionInfo>());
            }
            collisionBuffer[collidable].Add(collisionInfo);
        }

        private void SendAllCollisions()
        {
            foreach(KeyValuePair<ICollidable, List<CollisionInfo>> collisionList in collisionBuffer)
            {
                collisionList.Key.OnCollision(collisionList.Value);
            }
            collisionBuffer.Clear();
        }

        public static Vector2 PosSnappedToEdge(Direction direction, Rectangle overlapRectangle, Vector2 overlappedPos)
        {
            switch (direction)
            {
                case Direction.up:
                    return new Vector2(overlappedPos.X, overlappedPos.Y + overlapRectangle.Height);
                case Direction.down:
                    return new Vector2(overlappedPos.X, overlappedPos.Y - overlapRectangle.Height);
                case Direction.right:
                    return new Vector2(overlappedPos.X - overlapRectangle.Width, overlappedPos.Y);
                case Direction.left:
                    return new Vector2(overlappedPos.X + overlapRectangle.Width, overlappedPos.Y);
                default:
                    return Vector2.Zero;
            }
        }
    }
}
