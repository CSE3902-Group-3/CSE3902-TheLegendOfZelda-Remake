using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Enemies.Wizard
{
    public class Wizard : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private readonly ISprite wizardSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double lastSwitch = 0;

        public Wizard(Vector2 pos)
        {
            game = Game1.instance;
            spriteFactory = game.spriteFactory;
            wizardSprite = null; // Need to pull Wizard sprite from the sprite sheet
            Position = pos;
        }
        public void ChangePosition()
        {
            // Wizard does not have extra functionality, other than being drawn for Sprint 2
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
            // Wizard does not have extra functionality, other than being drawn for Sprint 2
        }

        public void Update(GameTime gameTime)
        {
           // Wizard does not have extra functionality, other than being drawn for Sprint 2
        }

        public void Draw()
        {
            wizardSprite.Draw();
        }
    }
}
