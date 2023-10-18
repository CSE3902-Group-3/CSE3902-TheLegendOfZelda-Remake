﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bomb : IItem, ICollidable
    {
        protected AnimatedSprite bomb;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Bomb(Vector2 pos)
        {
            bomb = SpriteFactory.getInstance().CreateBombSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            bomb.RegisterSprite();
            bomb.UpdatePos(position);
        }

        public void Remove()
        {
            bomb.UnregisterSprite();
        }

        public IItem Collect()
        {
            bomb.UnregisterSprite();
            return this;
        }

        public void Use(Vector2 newPos)
        {
            bomb.RegisterSprite();
            bomb.UpdatePos(newPos);
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

