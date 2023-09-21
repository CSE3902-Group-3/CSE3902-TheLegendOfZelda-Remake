using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Fairy : IItem
    {
        private Game1 game1;
        protected AnimatedSprite fairy;
        private SpriteFactory spriteFactory;


        public Fairy()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            fairy = spriteFactory.CreateFairySprite();
        }

        public void Draw()
        {
            fairy.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

