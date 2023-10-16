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
            SpriteFactory.getInstance().CreateBlueCandleSprite();
            position = pos;
            collider.Pos = position;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
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
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

