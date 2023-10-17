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
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
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
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

