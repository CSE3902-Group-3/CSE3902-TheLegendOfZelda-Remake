using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class HeartContainer : IItem
    {
        protected AnimatedSprite heartContainer;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public HeartContainer(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            heartContainer = spriteFactory.CreateHeartContainerSprite();
            position = pos;
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
    }
}

