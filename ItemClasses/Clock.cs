﻿using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Clock : IItem
    {
        protected AnimatedSprite clock;
        private SpriteFactory spriteFactory;


        public Clock(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            clock = spriteFactory.CreateClockSprite();
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

