﻿using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class HeartContainer : IItem
    {
        protected AnimatedSprite heartContainer;
        private SpriteFactory spriteFactory;


        public HeartContainer(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heartContainer = spriteFactory.CreateHeartContainerSprite();
        }

        public void Remove()
        {
            heartContainer.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

