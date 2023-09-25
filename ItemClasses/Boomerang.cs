using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Boomerang : IItem
    {
        protected AnimatedSprite boomerang;
        private SpriteFactory spriteFactory;


        public Boomerang(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            boomerang = spriteFactory.CreateBoomerangItemSprite();
        }

        public void Remove()
        {
            boomerang.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

