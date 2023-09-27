using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Clock : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author

        protected AnimatedSprite clock;
        private SpriteFactory spriteFactory;


        public Clock(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            clock = spriteFactory.CreateClockSprite();
            clock.UpdatePos(pos);
        }

        public void Remove()
        {
            clock.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

