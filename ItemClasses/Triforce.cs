using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Triforce : IItem, ICollidable
    {
        protected AnimatedSprite triforce;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Triforce(Vector2 pos)
        {
            triforce = SpriteFactory.getInstance().CreateTriforcePieceSprite();
            position = pos;
            collider.Pos = position;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 12 * scale, 16 * scale), CollisionLayer.Item, this);
        }

        public void Show()
        {
            triforce.RegisterSprite();
            triforce.UpdatePos(position);
        }

        public void Remove()
        {
            triforce.UnregisterSprite();
        }

        public IItem Collect()
        {
            triforce.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

