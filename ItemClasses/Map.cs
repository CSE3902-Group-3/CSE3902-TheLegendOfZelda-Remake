using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Map : IItem, ICollidable
    {
        protected AnimatedSprite map;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Map(Vector2 pos)
        {
            map = SpriteFactory.getInstance().CreateMapSprite();
            position = pos;
            collider.Pos = position;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
        }

        public void Show()
        {
            map.RegisterSprite();
            map.UpdatePos(position);
        }

        public void Remove()
        {
            map.UnregisterSprite();
        }

        public IItem Collect()
        {
            map.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

