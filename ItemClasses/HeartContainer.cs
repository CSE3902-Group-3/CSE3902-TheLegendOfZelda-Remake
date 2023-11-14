using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class HeartContainer : IItem, ICollidable
    {
        protected AnimatedSprite heartContainer;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public HeartContainer(Vector2 pos)
        {
            heartContainer = SpriteFactory.getInstance().CreateHeartContainerSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 16 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            heartContainer.RegisterSprite();
            heartContainer.UpdatePos(position);
        }

        public void Remove()
        {
            heartContainer.UnregisterSprite();
        }

        public IItem Collect()
        {
            heartContainer.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            heartContainer.RegisterSprite();
            heartContainer.UpdatePos(newPos);
        }

        public IItem GenerateInventoryItem()
        {
            //All item in inventory will have a zero position
            return new HeartContainer(Vector2.Zero);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.Player)
                {
                    Collect();
                }
            }
        }

        public bool Shown()
        {
            return false;
        }
    }
}

