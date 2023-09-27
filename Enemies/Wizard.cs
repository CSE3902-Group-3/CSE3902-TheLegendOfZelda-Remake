using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private AnimatedSprite wizardSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;

        public Wizard(Vector2 pos)
        {
            game = Game1.instance;
            Position = pos;
            wizardSprite = game.spriteFactory.CreateOldManSprite();
        }
        public void Spawn()
        {
            game.RegisterUpdateable(this);           
            wizardSprite.RegisterSprite();
            wizardSprite.UpdatePos(Position);
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
    }
}
