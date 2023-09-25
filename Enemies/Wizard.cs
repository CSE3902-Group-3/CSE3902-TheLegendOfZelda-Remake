using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies
{
    public class Wizard : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private readonly AnimatedSprite wizardSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;

        public Wizard(Vector2 pos)
        {
            game = Game1.instance;
            spriteFactory = game.spriteFactory;
            wizardSprite = spriteFactory.CreateOldManSprite();
            Position = pos;
        }
        public void ChangePosition()
        {
            wizardSprite.UpdatePos(Position);
        }
        public void Attack()
        {
            // Wizard does not attack unless attacked.
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
            // Wizard does not change direction
        }

        public void Die()
        {
            wizardSprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }
        public void Update(GameTime gameTime) {}

        public void Spawn()
        {
            wizardSprite.RegisterSprite();
            game.RegisterUpdateable(this);
            wizardSprite.UpdatePos(Position);
        }
    }
}
