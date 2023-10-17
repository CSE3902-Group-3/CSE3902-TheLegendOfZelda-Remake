using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
            rupee = SpriteFactory.getInstance().CreateBlinkingRupeeSprite();
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
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}
