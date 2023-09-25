using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Arrow : IItem
    {
        protected AnimatedSprite arrow;
        private SpriteFactory spriteFactory;


        public Arrow(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            arrow = spriteFactory.CreateArrowUpSprite();
        }

        public void Remove()
        {
            arrow.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }

        
    }
}

