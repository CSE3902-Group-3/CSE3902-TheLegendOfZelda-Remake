﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class FiveRupee : IItem, ICollidable
    {
        protected AnimatedSprite rupee;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public FiveRupee(Vector2 pos)
        {
            rupee = SpriteFactory.getInstance().CreateRupeeSprite();
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
            collider.Active = false;
            SoundFactory.PlaySound(SoundFactory.getInstance().GetRupee);
            return this;
        }

        public void Use(Vector2 newPos)
        {
            rupee.RegisterSprite();
            rupee.UpdatePos(newPos);
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
    }
}
