﻿using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    public class ZolBig : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private readonly AnimatedSprite zolBigSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double lastSwitch = 0;

        public ZolBig(Vector2 pos)
        {
            game = Game1.instance;
            game.RegisterUpdateable(this);
            spriteFactory = game.spriteFactory;
            zolBigSprite = spriteFactory.CreateZolSprite();
            Position = pos;

            zolBigSprite.UnregisterSprite();
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
            zolBigSprite.UpdatePos(Position);
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
            zolBigSprite.UnregisterSprite();

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
            zolBigSprite.RegisterSprite();
        }
        public void Die()
        {
            zolBigSprite.UnregisterSprite();
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 1000)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }

        public void Draw()
        {
            zolBigSprite.Draw();
        }
    }
}
