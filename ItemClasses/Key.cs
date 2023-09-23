using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Key : IItem
    {
        private Game1 game1;
        protected AnimatedSprite key;
        private SpriteFactory spriteFactory;


        public Key()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            key = spriteFactory.CreateKeySprite();
        }

        public void Remove()
        {
            key.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

