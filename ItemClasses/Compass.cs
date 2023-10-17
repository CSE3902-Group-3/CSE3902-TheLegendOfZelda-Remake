using LegendOfZelda;
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
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
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
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

