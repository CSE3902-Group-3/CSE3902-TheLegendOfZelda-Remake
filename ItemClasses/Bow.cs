using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bow : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author

        protected AnimatedSprite bow;
        private SpriteFactory spriteFactory;


        public Bow(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            bow = spriteFactory.CreateBowSprite();
            bow.UpdatePos(pos);
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

