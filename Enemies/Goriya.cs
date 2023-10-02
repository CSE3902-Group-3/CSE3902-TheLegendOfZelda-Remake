using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private readonly Game1 Game;
        private readonly List<AnimatedSprite> GoriyaSprites;
        private int CurrentSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private Vector2 ViewportSize;
        private double LastSwitch = 0;
        private int UpdateCount = 0;
        public Goriya(Vector2 pos)
        {
            game = Game1.getInstance();
            Position = pos;
            ViewportSize = new Vector2(Game.GraphicsDevice.Viewport.Width, Game.GraphicsDevice.Viewport.Height);
            GoriyaSprites = new List<AnimatedSprite>
            {
                Game.spriteFactory.CreateGoriyaRightSprite(),
                Game.spriteFactory.CreateGoriyaLeftSprite(),
                Game.spriteFactory.CreateGoriyaDownSprite(),
                Game.spriteFactory.CreateGoriyaUpSprite()
            };

            foreach (AnimatedSprite goriya in GoriyaSprites)
            {
                goriya.UnregisterSprite();
            }
        }
        public void Spawn()
        {
            Game.RegisterUpdateable(this);           
            GoriyaSprites[CurrentSprite].RegisterSprite();
            GoriyaSprites[CurrentSprite].UpdatePos(Position);
        }
        public void ChangePosition()
        {
            Position += Direction;
            if (Position.X < 0 || Position.Y < 0)
            {
                Position -= Direction;
            }

            if (Position.X >= ViewportSize.X || Position.Y >= ViewportSize.Y)
            {
                ChangeDirection();
            }
            GoriyaSprites[CurrentSprite].UpdatePos(Position);
        }
        public void Attack()
        {
            new GoriyaBoomerang(Position, Direction * 3);
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
            GoriyaSprites[CurrentSprite].UnregisterSprite();
            CurrentSprite = random;

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
            GoriyaSprites[CurrentSprite].RegisterSprite();
        }
        public void Die()
        {
            GoriyaSprites[CurrentSprite].UnregisterSprite();
            Game.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                UpdateCount++;

                ChangeDirection();

                if (UpdateCount % 4 == 0)
                {
                    Attack();
                }
            }
            ChangePosition();
        }
    }
}
