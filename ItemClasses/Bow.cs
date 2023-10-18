﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bow : IItem, ICollidable
    {
        protected AnimatedSprite bow;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Bow(Vector2 pos)
        {
            bow = SpriteFactory.getInstance().CreateBowSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            bow.RegisterSprite();
            bow.UpdatePos(position);
        }

        public void Remove()
        {
            bow.UnregisterSprite();
        }

        public IItem Collect()
        {
            bow.UnregisterSprite();
            return this;
        }

        public void Use(Vector2 newPos)
        {
            bow.RegisterSprite();
            bow.UpdatePos(newPos);
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

