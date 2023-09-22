using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Triforce : IItem
    {
        private Game1 game1;
        protected AnimatedSprite triforce;
        private SpriteFactory spriteFactory;


        public Triforce()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            triforce = spriteFactory.CreateTriforcePieceSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

