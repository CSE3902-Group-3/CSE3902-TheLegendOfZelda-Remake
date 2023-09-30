﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Triforce : IItem
    {
        protected AnimatedSprite triforce;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Triforce(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            triforce = spriteFactory.CreateTriforcePieceSprite();
            position = pos;
        }

        public void Show()
        {
            triforce.RegisterSprite();
            triforce.UpdatePos(position);
        }

        public void Remove()
        {
            triforce.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

