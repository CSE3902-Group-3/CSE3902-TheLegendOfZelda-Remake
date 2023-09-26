using LegendOfZelda;
using LegendOfZelda.Interfaces;
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
            spriteFactory = Game1.instance.spriteFactory;
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

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

