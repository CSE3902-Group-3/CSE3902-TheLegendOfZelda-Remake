using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Candle : IItem, ICollidable
    {
        protected AnimatedSprite candle;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Candle(Vector2 pos)
        {
            candle = SpriteFactory.getInstance().CreateBlueCandleSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().Candle, 1.0f, 0.0f, 0.0f);
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            candle.RegisterSprite();
            candle.UpdatePos(position);
        }

        public void Remove()
        {
            candle.UnregisterSprite();
        }

        public IItem Collect()
        {
            candle.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            candle.RegisterSprite();
            candle.UpdatePos(newPos);
        }

        public IItem GenerateInventoryItem()
        {
            //All item in inventory will have a zero position
            return new Candle(Vector2.Zero);
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

