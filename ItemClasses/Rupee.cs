﻿using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Rupee : IItem
    {
        private Game1 game1;
        protected AnimatedSprite rupee;
        private SpriteFactory spriteFactory;


        public Rupee()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            rupee = spriteFactory.CreateRupeeSprite();
        }

        public void Draw()
        {
            rupee.Draw();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

