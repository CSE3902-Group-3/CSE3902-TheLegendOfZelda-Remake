using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Key : IItem, ICollidable
    {
        protected AnimatedSprite key;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Key(Vector2 pos)
        {
            key = SpriteFactory.getInstance().CreateKeySprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            key.RegisterSprite();
            key.UpdatePos(position);
        }

        public void Remove()
        {
            key.UnregisterSprite();
        }

        public IItem Collect()
        {
            key.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

