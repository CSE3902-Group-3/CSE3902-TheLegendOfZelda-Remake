using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Clock : IItem, ICollidable
    {
        protected AnimatedSprite clock;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Clock(Vector2 pos)
        {
            clock = SpriteFactory.getInstance().CreateClockSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 12 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            clock.RegisterSprite();
            clock.UpdatePos(position);
        }

        public void Remove()
        {
            clock.UnregisterSprite();
        }

        public IItem Collect()
        {
            clock.UnregisterSprite();
            collider = null;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            clock.RegisterSprite();
            clock.UpdatePos(newPos);
        }

        public IItem GenerateInventoryItem()
        {
            //All item in inventory will have a zero position
            return new Arrow(Vector2.Zero);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            //The body of OnCollision is to meet requirement of sprint3 and will be refactored in sprint4
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.Player)
                {
                    Collect();
                }
            }
        }
    }
}

