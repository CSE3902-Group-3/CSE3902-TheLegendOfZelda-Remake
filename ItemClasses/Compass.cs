﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Compass : IItem, ICollidable
    {
        protected AnimatedSprite compass;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Compass(Vector2 pos)
        {
            compass = SpriteFactory.getInstance().CreateCompassSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 12 * scale, 12 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            compass.RegisterSprite();
            compass.UpdatePos(position);
        }

        public void Remove()
        {
            compass.UnregisterSprite();
        }

        public IItem Collect()
        {
            compass.UnregisterSprite();
            collider = null;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            compass.RegisterSprite();
            compass.UpdatePos(newPos);
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

