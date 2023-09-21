using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bomb : IItem
    {
        private Game1 game1;
        protected AnimatedSprite bomb;
        private SpriteFactory spriteFactory;


        public Bomb()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            bomb = spriteFactory.CreateBombSprite();
        }

        public void Draw()
        {
            bomb.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

