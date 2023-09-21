using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Boomerang : IItem
    {
        private Game1 game1;
        protected AnimatedSprite boomerang;
        private SpriteFactory spriteFactory;


        public Boomerang()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            boomerang = spriteFactory.CreateBoomerangItemSprite();
        }

        public void Draw()
        {
            boomerang.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

