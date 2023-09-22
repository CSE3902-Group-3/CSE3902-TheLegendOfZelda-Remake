using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Potion : IItem
    {
        private Game1 game1;
        protected AnimatedSprite potion;
        private SpriteFactory spriteFactory;


        public Potion()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            potion = spriteFactory.CreateBluePotionSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

