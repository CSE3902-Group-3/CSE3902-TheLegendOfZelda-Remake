using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Rupee : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite rupee;
        private SpriteFactory spriteFactory;


        public Rupee(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            rupee = spriteFactory.CreateRupeeSprite();
            rupee.UpdatePos(pos);
        }

        public void Remove()
        {
            rupee.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

