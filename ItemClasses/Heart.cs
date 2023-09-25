using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Heart : IItem
    {
        protected AnimatedSprite heart;
        private SpriteFactory spriteFactory;


        public Heart(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heart = spriteFactory.CreateHeartSprite();
        }

        public void Remove()
        {
            heart.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

