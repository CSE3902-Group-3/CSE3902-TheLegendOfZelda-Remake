using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private Game1 game;
        public SpriteFactory spriteFactory;
        private List<AnimatedSprite> goriyaSprites;
        private int currentSprite;
        private int health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double lastSwitch = 0;

        public Goriya(Vector2 pos)
        {
            game = Game1.getInstance();
            Position = pos;
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
            goriyaSprites[currentSprite].UpdatePos(Position);
        }
        public void ChangePosition()
        {
            Position += Direction;
            if (Position.X < 0 || Position.Y < 0)
            {
                Position -= Direction;
            }

            // This is kinda cursed, but it's to make sure the sprite does not venture beyond the screen border
            if (Position.X >= game.GraphicsDevice.Viewport.Width || Position.Y >= game.GraphicsDevice.Viewport.Height)
            {
                ChangeDirection();
            }
            goriyaSprites[currentSprite].UpdatePos(Position);
        }
        public void Attack()
        {
            //new GoriyaBoomerang(Position, Direction);
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
            Random rand = new Random();
            int random = rand.Next(0, 4);
            goriyaSprites[currentSprite].UnregisterSprite();
            currentSprite = random;

            if (random == 0)
            {
                Direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                Direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                Direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                Direction = new Vector2(0, -1);
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
            if (gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 100)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                Attack();
                ChangeDirection();
            }
            ChangePosition();
        }
    }
}
