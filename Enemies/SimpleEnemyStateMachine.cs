using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class SimpleEnemyStateMachine : IEnemy
    {
        private readonly Game1 game;
        public AnimatedSprite Sprite { get; set; }
        public enum Speed { slow, medium, fast };
        public int Health { get; set; }
        public Vector2 position;
        private Vector2 direction;
        public Vector2 viewportSize;
        private double lastSwitch = 0;

        public SimpleEnemyStateMachine(Vector2 pos)
        {
            game = Game1.instance;
            position = pos;
            viewportSize = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
        }
        public void Attack()
        {
            /* 
            * This isn't needed for Sprint 2,
            * however it will be needed later.
            */
        }

        public void ChangeDirection()
        {
            Random rand = new();
            int random = rand.Next(0, 4);

            if (random == 0)
            {
                direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                direction = new Vector2(0, -1);
            }
        }

        public void ChangePosition()
        {
            position += direction;
            if (position.X < 0 || position.Y < 0)
            {
                position -= direction;
            }

            if (position.X >= viewportSize.X || position.Y >= viewportSize.Y)
            {
                ChangeDirection();
            }
            Sprite.UpdatePos(position);
        }

        public void Die()
        {
            Sprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }

        public void Spawn()
        {
            game.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(position);
        }

        public void Update(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 0)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }

        public void UpdateHealth(int damagePoints)
        {
            Health -= damagePoints;

            // Indicate damage, or if health has reached 0, die
            if (Health < 0)
            {
                Die();
            } else
            {
                Sprite.blinking = true;
            }
            Sprite.blinking = false;
        }
    }
}
