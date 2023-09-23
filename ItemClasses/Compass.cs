using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Compass : IItem
    {
        private Game1 game1;
        protected AnimatedSprite compass;
        private SpriteFactory spriteFactory;


        public Compass()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            compass = spriteFactory.CreateCompassSprite();
        }

        public void Remove()
        {
            compass.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

