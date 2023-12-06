using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        public AnimatedSprite Sprite { get; set; }
        public float Health { get; set; } = 6.0f;
        public int Width { get; } = 24;
        public int Height { get; } = 32;
        public Type EnemyType { get; set; }
        public EnemyItemDrop.EnemyClass Classification { get; } = EnemyItemDrop.EnemyClass.D;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new(0, 0);
        public Vector2 Offset { get; set; } = new(0, 0);
        public RectCollider Collider { get; }
        public bool IsColliding { get; set; } = false;
        public bool Frozen { get; set; } = false;

        public bool AllowedToMove { get; set; } = true;
        public Vector2 SpeedMultiplier { get; set; } = new(1, 1);
        public float CurrentCooldown { get; set; } = 0.0f;
        public double LastSwitch { get; set; } = 0;

        private int FireballSpeed = 5;
        private Vector2 Center;
        private int CycleCount = 0;
        private readonly int MaxCycles = 50;
        private int PosIncrement = 1;
        public Aquamentus(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateAquamentusSprite();
            Sprite.UnregisterSprite();
            LevelManager.AddUpdateable(this);
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, Width * scale, Height * scale),
               CollisionLayer.Enemy,
               this
           );
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
            LevelManager.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
            LevelManager.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void ChangePosition()
        {
            Vector2 newPosition = new(Position.X, Position.Y);
            
            if (!Frozen)
            {
                // Cycle left and right movement
                if (CycleCount > MaxCycles)
                {
                    CycleCount = 0;
                    PosIncrement *= -1;
                }

                newPosition.X += PosIncrement;
                CycleCount++;
            }

            Position = newPosition;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack()
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossScream1);
            new AquamentusBall(Position, new Vector2(-FireballSpeed, 0));
            new AquamentusBall(Position, new Vector2(-FireballSpeed, FireballSpeed));
            new AquamentusBall(Position, new Vector2(-FireballSpeed, -FireballSpeed));
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
                SoundFactory.PlaySound(SoundFactory.getInstance().BossHit);
            }
        }

        public void ChangeDirection()
        {
            // Aquamentus cycles left and right movement,
            // but it does not change the direction it is
            // facing
        }

        public void Update(GameTime gameTime)
        {
            CurrentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
            ChangePosition();
            if (CycleCount == MaxCycles)
            {
                Attack();
            }
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
                    if (CurrentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        CurrentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        Sprite.flashing = true;
                        new Timer(1.0f, StopFlashing);
                    }
                }
            }
        }
        public void Stun() { }
        public void StopFlashing()
        {
            Sprite.flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, Width, Height);
            EnemyItemDrop.DropClassDItem(Center);
        }
    }
}