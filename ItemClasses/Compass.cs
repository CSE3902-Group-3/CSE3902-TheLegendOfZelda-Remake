﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Compass : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite compass;
        private SpriteFactory spriteFactory;


        public Compass(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            compass = spriteFactory.CreateCompassSprite();
            compass.UpdatePos(pos);
        }

        public void Remove()
        {
            compass.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

