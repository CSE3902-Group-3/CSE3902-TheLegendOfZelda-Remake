using LegendOfZelda.EnemyProjectiles;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    public class Aquamentus : IEnemy
    {
        private Game1 game { get; set; }
        private AnimatedSprite AquamentusSprite;
        private int Health { get; set; } = 1;
        private Vector2 Position;
        private int CycleCount = 0;
        private int MaxCycles = 50;
        private int PosIncrement = 2;

        public Aquamentus(Vector2 pos)
        {
            game = Game1.instance;
            Position = pos;
            AquamentusSprite = game.spriteFactory.CreateAquamentusSprite();
        }
        public void Spawn ()
        {
            game.RegisterUpdateable(this);
            AquamentusSprite.RegisterSprite();
            AquamentusSprite.UpdatePos(Position);
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
            new AquamentusBall(Position, new Vector2(-10, 0));
            new AquamentusBall(Position, new Vector2(-10, 10));
            new AquamentusBall(Position, new Vector2(-10, -10));
        }
        public void UpdateHealth()
        {
            // Not needed
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
        public void Die()
        {
            AquamentusSprite.UnregisterSprite();
            Game1.instance.RemoveUpdateable(this);
        }
    }
}
