using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Heart : IItem
    {
        private Game1 game1;
        protected AnimatedSprite heart;
        private SpriteFactory spriteFactory;


        public Heart()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heart = spriteFactory.CreateHeartSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

