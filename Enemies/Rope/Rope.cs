using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Rope
{
    public class Rope : IEnemy
    {
        private Game1 Game { get; set; }
        private ISprite RopeSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private int PosIncrement = 5;
        private Boolean facingLeft = false;
        private double LastDirSwitch = 0;

        public Rope(Vector2 pos)
        {
            Game1.instance.RegisterUpdateable(this);
            RopeSprite = Game1.instance.spriteFactory.CreateRopeRightSprite();
            Position = pos;
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

        public void Draw()
        {
            RopeSprite.Draw();
        }
        public void Destroy()
        {
            Game1.instance.RemoveDrawable(RopeSprite);
            Game1.instance.RemoveUpdateable(this);
        }
    }
}
