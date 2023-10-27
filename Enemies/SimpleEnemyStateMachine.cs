using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static LegendOfZelda.EnemyItemDrop;

namespace LegendOfZelda
{
    public class SimpleEnemyStateMachine : IEnemy
    {
        public EnemyClass Classification {get; set;}
        public AnimatedSprite Sprite { get; set; }
        public enum Speed { slow, medium, fast };
        public Speed EnemySpeed { get; set; }
        public int SpeedMultiplier;
        public float Health { get; set; }
        private Vector2 Position;
        private Vector2 Offset;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private float currentCooldown = 0.0f;
        public RectCollider Collider { get; set; }

        public SimpleEnemyStateMachine(Vector2 pos, Vector2 offset, RectCollider collider)
        {
            Position = pos;
            Offset = offset;

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
            Collider = collider;
        }
        public void Attack() {}

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
            Sprite.UpdatePos(Position);
            Collider.Active = false;
            new EnemyDeathEffect(Position);
            Sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
            DropItem();
        }

        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
            Collider.Pos = Position + Offset;
        }

        public void Update(GameTime gameTime)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
            Collider.Pos = Position + Offset;
        }

        public void UpdateHealth(float damagePoints)
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
        }

        public void OnCollision(List<CollisionInfo> collisions) {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (currentCooldown <= 0)
                    {
                        UpdateHealth(1.0f); // Choose different values for each type of player weapon
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                    }
                }
            }
        }
        public void DropItem()
        {
            Drop(Classification, Position);
        }
    }
}
