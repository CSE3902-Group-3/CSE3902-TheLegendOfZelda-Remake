﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bomb : IItem
    {
        protected AnimatedSprite bomb;
        private Vector2 position;

        public Bomb(Vector2 pos)
        {
            bomb = SpriteFactory.getInstance().CreateBombSprite();
            position = pos;
        }

        public void Show()
        {
            bomb.RegisterSprite();
            bomb.UpdatePos(position);
        }

        public void Remove()
        {
            bomb.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

