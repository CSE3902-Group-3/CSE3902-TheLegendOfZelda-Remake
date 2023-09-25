using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Heart : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite heart;
        private SpriteFactory spriteFactory;


        public Heart(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heart = spriteFactory.CreateHeartSprite();
            heart.UpdatePos(pos);
        }

        public void Remove()
        {
            heart.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

