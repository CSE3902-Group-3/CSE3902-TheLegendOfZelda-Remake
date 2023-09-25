using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bow : IItem
    {
        protected AnimatedSprite bow;
        private SpriteFactory spriteFactory;


        public Bow(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            bow = spriteFactory.CreateBowSprite();
        }

        public void Remove()
        {
            bow.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

