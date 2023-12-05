using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Rope : IEnemy
    {
        public AnimatedSprite Sprite { get; set; }
        public int Width { get; set; } = 16;
        public int Height { get; set; } = 16;
        public Type EnemyType { get; set; }
        public EnemyItemDrop.EnemyClass Classification { get; } = EnemyItemDrop.EnemyClass.B;
        public float Health { get; set; } = 0.5f;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new(0, 0);
        public Vector2 Offset { get; set; } = new(0, 0);
        public Vector2 SpeedMultiplier { get; set; } = new(1, 1);
        public double LastSwitch { get; set; } = 0;
        public float CurrentCooldown { get; set; } = 0.0f;
        public bool AllowedToMove { get; set; } = true;
        public bool IsColliding { get; set; } = false;
        public RectCollider Collider { get; private set; }
        public bool Frozen { get; set; } = false;
        public Vector2 Center;
        private readonly int PosIncrement = 5;
        private bool FacingLeft = false;
        public Rope(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();
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

            if (!Frozen && AllowedToMove)
            {
                // Cycle left and right movement
                if (FacingLeft)
                {
                    newPosition.X -= PosIncrement;
                }
                else
                {
                    newPosition.X += PosIncrement;
                }

                Position = newPosition;
                Sprite.UpdatePos(Position);
                Collider.Pos = Position;
            }
        }
        public void Attack() { }
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
                SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
            }
        }

        public void ChangeDirection()
        {
            Sprite.UnregisterSprite();
            if (FacingLeft)
            {
                Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();
            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateRopeLeftSprite();
            }
            FacingLeft = !FacingLeft;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }

        public void Update(GameTime gameTime)
        {
            CurrentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000 && IsColliding == false)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    IsColliding = true;
                    ChangeDirection();
                    Sprite.UpdatePos(Position);
                    Collider.Pos = Position;
                    ChangePosition();
                    IsColliding = false;
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
        public void Stun()
        {
            AllowedToMove = false;
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
            new Timer(2.0f, CompleteStun);
        }
        public void CompleteStun()
        {
            AllowedToMove = true;
        }
        public void StopFlashing()
        {
            Sprite.flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, 16, 16);
            EnemyItemDrop.DropClassBItem(Center);
        }
    }
}
