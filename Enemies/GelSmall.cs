﻿using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{

    public class GelSmall : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private AnimatedSprite gelSmallSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double lastSwitch = 0;

        public GelSmall(Vector2 pos)
        {
            game = Game1.instance;
            Position = pos;
            gelSmallSprite = game.spriteFactory.CreateGelSprite();
        }
        public void Spawn()
        {
            game.RegisterUpdateable(this);            
            gelSmallSprite.RegisterSprite();
            gelSmallSprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            Position += Direction;
            if (Position.X < 0 || Position.Y < 0)
            {
                Position -= Direction;
            }

            // This is kinda cursed, but it's to make sure the sprite does not venture beyond the screen border
            if (Position.X >= game.GraphicsDevice.Viewport.Width || Position.Y >= game.GraphicsDevice.Viewport.Height)
            {
                Position -= Direction;
            }
            gelSmallSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            /* 
             * This isn't needed for Sprint 2,
             * however it will be needed later.
             */
        }
        public void UpdateHealth()
        {
            /* 
             * This isn't needed for Sprint 2,
             * however it will be needed later.
             */
        }

        public void ChangeDirection()
        {
            Random rand = new Random();
            int random = rand.Next(0, 4);

            if (random == 0)
            {
                Direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                Direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                Direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                Direction = new Vector2(0, -1);
            }
        }
        public void Die()
        {
            gelSmallSprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 100)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
    }
}
