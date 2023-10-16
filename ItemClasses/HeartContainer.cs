using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class HeartContainer : IItem, ICollidable
    {
        protected AnimatedSprite heartContainer;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public HeartContainer(Vector2 pos)
        {
            heartContainer = SpriteFactory.getInstance().CreateHeartContainerSprite();
            position = pos;
            collider.Pos = position;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 8 * scale), CollisionLayer.Item, this);
        }

        public void Show()
        {
            heartContainer.RegisterSprite();
            heartContainer.UpdatePos(position);
        }

        public void Remove()
        {
            heartContainer.UnregisterSprite();
        }

        public IItem Collect()
        {
            heartContainer.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

