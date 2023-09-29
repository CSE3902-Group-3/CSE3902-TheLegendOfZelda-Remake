using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private readonly Game1 game;
        private readonly List<AnimatedSprite> goriyaSprites;
        private int currentSprite;
        private int Health { get; set; } = 1;
        public Vector2 position;
        private Vector2 direction;
        private readonly Direction dir;
        private Vector2 viewportSize;
        private double lastSwitch = 0;
        private int updateCount = 0;
        public Goriya(Vector2 pos)
        {
            game = Game1.instance;
            position = pos;
            dir = Direction.right;
            viewportSize = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
            goriyaSprites = new List<AnimatedSprite>
            {
                game.spriteFactory.CreateGoriyaRightSprite(),
                game.spriteFactory.CreateGoriyaLeftSprite(),
                game.spriteFactory.CreateGoriyaDownSprite(),
                game.spriteFactory.CreateGoriyaUpSprite()
            };

            foreach (AnimatedSprite goriya in goriyaSprites)
            {
                goriya.UnregisterSprite();
            }
        }
        public void Spawn()
        {
            game.RegisterUpdateable(this);           
            goriyaSprites[currentSprite].RegisterSprite();
            goriyaSprites[currentSprite].UpdatePos(position);
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
            goriyaSprites[currentSprite].UpdatePos(position);
        }
        public void Attack()
        {
            new GoriyaBoomerang(position, direction * 3);
        }
        public void UpdateHealth(int damagePoints)
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
            goriyaSprites[currentSprite].UnregisterSprite();
            currentSprite = random;

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
            goriyaSprites[currentSprite].RegisterSprite();
        }
        public void Die()
        {
            goriyaSprites[currentSprite].UnregisterSprite();
            game.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 1000)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                updateCount++;

                ChangeDirection();

                if (updateCount % 4 == 0)
                {
                    Attack();
                }
            }
            ChangePosition();
        }
    }
}
