﻿using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Candle : IItem
    {
        protected AnimatedSprite candle;
        private SpriteFactory spriteFactory;


        public Candle(Game1 game1)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            candle = spriteFactory.CreateBlueCandleSprite();
        }

        public void Remove()
        {
            candle.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

