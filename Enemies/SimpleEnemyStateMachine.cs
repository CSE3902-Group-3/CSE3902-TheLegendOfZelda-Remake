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
        public Vector2 Position { get; set; }
        private Vector2 Center;
        private Vector2 Offset;
        public Vector2 Direction;
        private double LastSwitch = 0;
        private float currentCooldown = 0.0f;
        private bool allowedToMove = true;
        public bool isColliding = false;
        public int Width;
        public int Height;
        public RectCollider Collider { get; set; }

        public SimpleEnemyStateMachine(Vector2 pos, Vector2 offset, RectCollider collider, IEnemy enemy = null)
        {
            Enemy = enemy;
            Position = pos;
            Offset = offset;
            Direction = new Vector2(1, 0);
            LevelMaster.AddUpdateable(this);

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
                Collider.Pos = Position + Offset;
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
            LevelMaster.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void Update(GameTime gameTime)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000 && isColliding == false)
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

                if (collidedWith == CollisionLayer.OuterWall || (EnemyType != typeof(Bat) && collidedWith == CollisionLayer.Wall)) // Bat should be able to float over inner walls
                {
                    isColliding = true;
                    Direction *= -1;
                    Sprite.UpdatePos(Position);
                    Collider.Pos = Position + Offset;
                    ChangePosition();
                    isColliding = false;
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
