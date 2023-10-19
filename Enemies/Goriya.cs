using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private readonly List<AnimatedSprite> GoriyaSprites;
        private int CurrentSprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private int UpdateCount = 0;
        public Goriya(Vector2 pos)
        {
            Position = pos;
            GoriyaSprites = new List<AnimatedSprite>
            {
                SpriteFactory.getInstance().CreateGoriyaRightSprite(),
                SpriteFactory.getInstance().CreateGoriyaLeftSprite(),
                SpriteFactory.getInstance().CreateGoriyaDownSprite(),
                SpriteFactory.getInstance().CreateGoriyaUpSprite()
            };

            foreach (AnimatedSprite goriya in GoriyaSprites)
            {
                goriya.UnregisterSprite();
            }
        }
        public void Spawn()
        {
            LevelMaster.RegisterUpdateable(this);           
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
            LevelMaster.RemoveUpdateable(this);
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
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall)
                {
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                }
            }
        }
    }
}
