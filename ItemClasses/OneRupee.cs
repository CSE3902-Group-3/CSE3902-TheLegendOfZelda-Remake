using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class OneRupee : IItem, ICollidable
    {
        protected AnimatedSprite rupee;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public OneRupee(Vector2 pos)
        {
            rupee = SpriteFactory.getInstance().CreateBlinkingRupeeSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            rupee.RegisterSprite();
            rupee.UpdatePos(position);
        }

        public void Remove()
        {
            rupee.UnregisterSprite();
        }

        public IItem Collect()
        {
            rupee.UnregisterSprite();
            return this;
        }

        public void Use(Vector2 newPos)
        {
            rupee.RegisterSprite();
            rupee.UpdatePos(newPos);
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

