using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Potion : IItem, ICollidable
    { 
        protected AnimatedSprite potion;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Potion(Vector2 pos)
        {
            potion = SpriteFactory.getInstance().CreateBluePotionSprite();
            position = pos;
            collider.Pos = position;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
        }

        public void Show()
        {
            potion.RegisterSprite();
            potion.UpdatePos(position);
        }

        public void Remove()
        {
            potion.UnregisterSprite();
        }

        public IItem Collect()
        {
            potion.UnregisterSprite();
            return this;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {

        }
    }
}

