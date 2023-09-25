using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    public class Rope : IEnemy
    {
        private Game1 Game { get; set; }
        private AnimatedSprite RopeSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private int PosIncrement = 5;
        private bool facingLeft = false;
        private double LastDirSwitch = 0;

        public Rope(Vector2 pos)
        {
            Position = pos;
        }
        public void Spawn()
        {
            Game1.instance.RegisterUpdateable(this);
            RopeSprite = Game1.instance.spriteFactory.CreateRopeRightSprite();
            RopeSprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (facingLeft)
            {
                Position.X -= PosIncrement;
            }
            else
            {
                Position.X += PosIncrement;
            }

            RopeSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            /* 
             * This isn't needed for Sprint 2, however it will be needed later.
             */
        }
        public void UpdateHealth()
        {
            /* 
             * This isn't needed for Sprint 2, however it will be needed later.
             */
        }

        public void ChangeDirection()
        {
            Game1.instance.RemoveDrawable(RopeSprite);
            if (facingLeft)
            {
                RopeSprite = Game1.instance.spriteFactory.CreateRopeRightSprite();
            }
            else
            {
                RopeSprite = Game1.instance.spriteFactory.CreateRopeLeftSprite();
            }
            facingLeft = !facingLeft;
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastDirSwitch + 1000)
            {
                LastDirSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
        public void Die()
        {
            RopeSprite.UnregisterSprite();
            Game1.instance.RemoveUpdateable(this);
        }
    }
}
