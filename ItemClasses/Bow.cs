using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bow : IItem
    {
        private Game1 game1;
        protected AnimatedSprite bow;
        private SpriteFactory spriteFactory;


        public Bow()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            bow = spriteFactory.CreateBowSprite();
        }

        public void Draw()
        {
            bow.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

