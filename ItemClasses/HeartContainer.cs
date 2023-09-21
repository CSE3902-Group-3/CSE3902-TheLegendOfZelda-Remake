using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class HeartContainer : IItem
    {
        private Game1 game1;
        protected AnimatedSprite heartContainer;
        private SpriteFactory spriteFactory;


        public HeartContainer()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heartContainer = spriteFactory.CreateHeartContainerSprite();
        }

        public void Draw()
        {
            heartContainer.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

