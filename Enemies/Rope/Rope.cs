﻿using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Rope
{
    public class Rope : IEnemy
    {
        private Game1 Game { get; set; }
        public SpriteFactory SpriteFactory;
        private readonly ISprite RopeSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private int CycleCount = 0;
        private int PosIncrement = 2;

        public Rope(Vector2 pos, SpriteFactory spriteFactory)
        {
            this.SpriteFactory = spriteFactory;
            RopeSprite = this.SpriteFactory.CreateRopeSprite();
            Position = pos;
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > 3)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }
            Position.X += PosIncrement;
            CycleCount++;

            RopeSprite.UpdatePos(Position);
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
            // Rope cycles left and right movement,
            // but it does not change the direction it is
            // facing
        }

        public void Update(GameTime gameTime)
        {
            /* 
             * I don't think there is a valid
             * implimentation for this at the moment.
             * This could be applicable when we 
             * have collision.
            */
        }

        public void Draw()
        {
            RopeSprite.Draw();
        }
    }
}
