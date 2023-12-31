﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class SelectionHeart : IItem
    {
        protected AnimatedSprite heart;
        private Vector2 position;
        private int scale = SpriteFactory.getInstance().scale;

        public SelectionHeart(Vector2 pos)
        {
            heart = SpriteFactory.getInstance().CreateHeartSprite();
            position = pos;
        }

        public void Show()
        {
            heart.RegisterSprite();
            heart.UpdatePos(position);
        }

        public void Remove()
        {
            heart.UnregisterSprite();
        }

        public IItem Collect()
        {
            // Not needed for this item
            return null;
        }

        public void Use(Vector2 newPos)
        {
            heart.RegisterSprite();
            heart.UpdatePos(newPos);
        }
    }
}

