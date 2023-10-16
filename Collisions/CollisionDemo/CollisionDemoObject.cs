//This class is not for the final game but for testing and demonstrating the collision system
//The comments on this object explain how to use the RectCollider object.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    //An object must implement ICollidable to respond to collisions
    public class CollisionDemoObject : ICollidable, IUpdateable
    {
        private IAnimatedSprite sprite;

        //The IRectCollider interface has all of the methods you need to use the RectCollider object.
        private IRectCollider collider;
        private Random random;
        private Vector2 speed;

        private Vector2 _position;
        private Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                sprite.UpdatePos(value);

                //Moving collider.Pos will move the top left corner of the collider
                collider.Pos = value;
            }
        }


        public CollisionDemoObject(IAnimatedSprite sprite, CollisionLayer layer, int width, int height) {
            this.sprite = sprite;
            random = new Random();

            _position = new Vector2((float)random.NextDouble() * 1000, (float)random.NextDouble() * 800);
            speed = new Vector2((float)random.NextDouble() * 2 + 2, (float)random.NextDouble() * 2 - 2);
            sprite.UpdatePos(_position);

            //You will almost certainly need to use this scale variable to know the size of your collider's rectangle
            int scale = SpriteFactory.getInstance().scale;

            /*
             * You will typically make your RectCollider in the constructor of the ICollidable object
             */
            collider = new RectCollider(

                /*
                 * The first parameter is the rectangle collision box. In this case I have a width by height pixel sprite, and I want the hitbox to
                 * cover the whole sprite, so I simply scale width and height. You may want to choose a smaller hitbox to be more lenient to the
                 * player. If you do, make sure to offset the position so that the box is centered.
                 */
                new Rectangle((int)_position.X, (int)+_position.Y, width * scale, height * scale),

                //The second parameter indicates what type of object this is (Player, Enemy, Wall, PlayerWeapon, or EnemyWeapon)
                layer,

                //The third parameter gives the ICollidable which must respond to the collisions on this collider. It is normally this
                this
            );

            Game1.getInstance().RegisterUpdateable(this);
        }

        /*
         * OnCollision will be called every frame that the collider has one or more collisions. The list of collisions contains every collision that
         * happened to that collider on that frame. The collision detector runs after Update and before Draw, so this is your last chance to move
         * an object's sprite in any given frame.
         */
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                /*
                 * You will likely need to sort out the collisions by the Layer of the collidable you collided with
                 */
                if (collision.CollidedWith.Layer == CollisionLayer.OuterWall || collision.CollidedWith.Layer == CollisionLayer.Wall)
                {
                    HandleCollisionWithWall(collision.EstimatedDirection, collision.OverlapRectangle);
                } else
                {
                    HandleCollisionWithEntity();
                }
            }
        }

        private void HandleCollisionWithWall(Direction direction, Rectangle overlapRectangle)
        {
            switch (direction)
            {
                case Direction.up:
                    //In this case I am changing the direction randomly to make the object bounce off of the wall
                    speed = new Vector2(speed.X, (float)random.NextDouble() * 2.5f + 2);

                    //This position adjustment "snaps" an object to the thing it collided with. Otherwise it would overlap it when drawn
                    Position = new Vector2(Position.X, Position.Y + overlapRectangle.Height);
                    break;
                case Direction.down:
                    speed = new Vector2(speed.X, -(float)random.NextDouble() * 2.5f - 2);
                    Position = new Vector2(Position.X, Position.Y - overlapRectangle.Height);
                    break;
                case Direction.right:
                    speed = new Vector2(-(float)random.NextDouble() * 2.5f - 2, speed.Y);
                    Position = new Vector2(Position.X - overlapRectangle.Width, Position.Y);
                    break;
                case Direction.left:
                    speed = new Vector2((float)random.NextDouble() * 2.5f + 2, speed.Y);
                    Position = new Vector2(Position.X + overlapRectangle.Width, Position.Y);
                    break;
            }
        }

        private void HandleCollisionWithEntity()
        {
            //In this case I just make the sprites flash random colors when colliding
            sprite.color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1);
        }

        public void Update(GameTime gameTime)
        {
            Position += speed;
        }
    }
}
