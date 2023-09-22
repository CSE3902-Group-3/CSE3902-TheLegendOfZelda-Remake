using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Aquamentus
{
    public class Aquamentus : IEnemy
    {
        private Game1 Game { get; set; }
        private ISprite AquamentusSprite;
        private int Health { get; set; } = 1;
        private Vector2 Position;
        private int CycleCount = 0;
        private int MaxCycles = 10;
        private int PosIncrement = 10;

        public Aquamentus(Vector2 pos)
        {
            AquamentusSprite = Game1.instance.spriteFactory.CreateAquamentusSprite();
            Game1.instance.RegisterDrawable(AquamentusSprite, 1);
            Position = pos;
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }
            Position.X += PosIncrement;
            CycleCount++;

            AquamentusSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            Game1.instance.RegisterUpdateable(new AquamentusBall(Position, new Vector2(-10, 0)));
            Game1.instance.RegisterUpdateable(new AquamentusBall(Position, new Vector2(-10, 10)));
            Game1.instance.RegisterUpdateable(new AquamentusBall(Position, new Vector2(-10, -10)));
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
            // Aquamentus cycles left and right movement,
            // but it does not change the direction it is
            // facing
        }

        public void Update(GameTime gameTime)
        {
            ChangePosition();
            if (CycleCount == MaxCycles)
            {
                Attack();
            }
        }

        public void Draw()
        {
            AquamentusSprite.Draw();
        }
    }
}
