using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Fairy : IItem
    {
        protected AnimatedSprite fairy;
        private SpriteFactory spriteFactory;


        public Fairy(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            fairy = spriteFactory.CreateFairySprite();
        }

        public void Remove()
        {
            fairy.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

