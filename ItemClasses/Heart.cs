using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Heart : IItem, ICollidable
    {
        protected AnimatedSprite heart;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Heart(Vector2 pos)
        {
            heart = SpriteFactory.getInstance().CreateBlinkingHeartSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            heart.RegisterSprite();
            heart.UpdatePos(position);
        }

        public void Remove()
        {
            heart.UnregisterSprite();
        }

        public IItem Collect()
        {
            heart.UnregisterSprite();
            collider = null;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            heart.RegisterSprite();
            heart.UpdatePos(newPos);
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

