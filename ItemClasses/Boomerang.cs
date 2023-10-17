using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Boomerang : IItem, ICollidable
    {
        protected AnimatedSprite boomerang;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Boomerang(Vector2 pos)
        {
            boomerang = SpriteFactory.getInstance().CreateBoomerangItemSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            boomerang.RegisterSprite();
            boomerang.UpdatePos(position);
        }

        public void Remove()
        {
            boomerang.UnregisterSprite();
        }

        public IItem Collect()
        {
            boomerang.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

