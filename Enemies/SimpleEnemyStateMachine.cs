using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class SimpleEnemyStateMachine : IEnemy
    {
        public AnimatedSprite Sprite { get; set; }
        public enum Speed { slow, medium, fast };
        public Speed EnemySpeed { get; set; }
        public int SpeedMultiplier;
        public int Health { get; set; }
        private Vector2 Position;
        private RectCollider Collider;
        private Vector2 Direction;
        private double LastSwitch = 0;
        public bool IsFlying { get; set; }

        public SimpleEnemyStateMachine(Vector2 pos)
        {
            Position = pos;
            Collider.Pos = pos;
            int scale = SpriteFactory.getInstance().scale;

            switch (EnemySpeed)
            {
                case Speed.slow:
                    SpeedMultiplier = 1;
                    break;
                case Speed.medium:
                    SpeedMultiplier = 2;
                    break;
                case Speed.fast:
                    SpeedMultiplier = 3;
                    break;
            }
            Collider = new RectCollider(new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale), CollisionLayer.Enemy, this);
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
        }

        public void ChangePosition()
        {
            Position += Direction * SpeedMultiplier;
            if (Position.X < 0 || Position.Y < 0)
            {
                Position -= Direction;
            }
            Sprite.UpdatePos(Position);
        }

        public void Die()
        {
            Sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
        }

        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }

        public void Update(GameTime gameTime)
        {

            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
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

                if (!IsFlying && collidedWith == CollisionLayer.Wall) { }
            }
        }
    }
}
