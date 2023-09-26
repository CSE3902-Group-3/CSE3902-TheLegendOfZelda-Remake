﻿using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Potion : IItem
    { 
        protected AnimatedSprite potion;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Potion(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            potion = spriteFactory.CreateBluePotionSprite();
            position = pos;
        }

        public void Show()
        {
            potion.RegisterSprite();
            potion.UpdatePos(position);
        }

        public void Remove()
        {
            potion.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

