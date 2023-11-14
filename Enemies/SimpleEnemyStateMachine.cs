using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static LegendOfZelda.EnemyItemDrop;

namespace LegendOfZelda
{
    public class SimpleEnemyStateMachine : IEnemy
    {
        private IEnemy Enemy;
        public EnemyClass Classification { get; set; }
        public AnimatedSprite Sprite { get; set; }
        public Type EnemyType { get; set; }
        public enum Speed { slow, medium, fast };
        public Speed EnemySpeed { get; set; }
        public int SpeedMultiplier;
        public float Health { get; set; }
        private Vector2 Position;
        private Vector2 Center;
        private Vector2 Offset;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private float currentCooldown = 0.0f;
        private bool allowedToMove = true;
        public int Width;
        public int Height;
        public RectCollider Collider { get; set; }

        public SimpleEnemyStateMachine(Vector2 pos, Vector2 offset, RectCollider collider, IEnemy enemy = null)
        {
            Enemy = enemy;
            Position = pos;
            Offset = offset;
            Direction = new Vector2(1, 0);
            LevelMaster.RegisterUpdateable(this);
            Sprite.UnregisterSprite();

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
        public void Attack() { }

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
            if (allowedToMove)
            {
                Position += Direction * SpeedMultiplier;
                Sprite.UpdatePos(Position);
            }
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            Sprite.RegisterSprite();
        }
        public void Despawn()
        {
            Sprite.UnregisterSprite();
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
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
                LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Remove(Enemy);
            }
            else
            {
                SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit, 1.0f, 0.0f, 0.0f);
            }
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
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
                        EnemyUtilities.HandleWeaponCollision(this, EnemyType, collision);
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        Sprite.flashing = true;
                        new Timer(1.0f, StopFlashing);
                    }
                }
            }
        }
        public void Stun()
        {
            allowedToMove = false;
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit, 1.0f, 0.0f, 0.0f);
            new Timer(2.0f, CompleteStun);
        }
        public void CompleteStun()
        {
            allowedToMove = true;
        }
        public void StopFlashing()
        {
            Sprite.flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, Width, Height);

            switch (Classification)
            {
                case EnemyClass.A:
                    DropClassAItem(Center);
                    break;
                case EnemyClass.B:
                    DropClassBItem(Center);
                    break;
                case EnemyClass.C:
                    DropClassCItem(Center);
                    break;
                case EnemyClass.D:
                    DropClassBItem(Center);
                    break;
                default:
                    break;
            }
        }
    }
}
