﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Dodongo : IEnemy
    {
        private readonly List<AnimatedSprite> Sprites;
        private readonly List<AnimatedSprite> HurtSprites;
        private int CurrentSprite;
        public AnimatedSprite Sprite { get; set; }
        public float Health { get; set; } = 8.0f;
        public int Width { get; } = 16;
        public int Height { get; } = 16;
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
        private Vector2 Center;
        private bool Injured = false;
        public Dodongo(Vector2 pos)
        {
            Position = pos;
            Sprites = new List<AnimatedSprite>
            {
                SpriteFactory.getInstance().CreateDodongoRightSprite(),
                SpriteFactory.getInstance().CreateDodongoLeftSprite(),
                SpriteFactory.getInstance().CreateDodongoDownSprite(),
                SpriteFactory.getInstance().CreateDodongoUpSprite()
            };

            HurtSprites = new List<AnimatedSprite>
            {
                SpriteFactory.getInstance().CreateDodongoRightHitSprite(),
                SpriteFactory.getInstance().CreateDodongoLeftHitSprite(),
                SpriteFactory.getInstance().CreateDodongoDownHitSprite(),
                SpriteFactory.getInstance().CreateDodongoUpHitSprite()
            };

            foreach (AnimatedSprite dodongo in Sprites)
            {
                dodongo.UnregisterSprite();
            }

            foreach (AnimatedSprite dodongo in HurtSprites)
            {
                dodongo.UnregisterSprite();
            }

            int scale = SpriteFactory.getInstance().scale;
            CurrentSprite = 0;
            LevelManager.AddUpdateable(this);

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, Width * scale, Height * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossScream2);
            new EnemySpawnEffect(Position);
            Sprites[CurrentSprite].RegisterSprite();
        }
        public void Despawn()
        {
            Sprites[CurrentSprite].UnregisterSprite();
        }
        public void Die()
        {
            Sprites[CurrentSprite].UnregisterSprite();
            Collider.Active = false;
            LevelManager.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
            LevelManager.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void ChangePosition()
        {
            if (!Frozen)
            {
                Position += Direction;
                Sprites[CurrentSprite].UpdatePos(Position);
                Collider.Pos = Position;
            }
        }
        public void Attack() { }
        public void UpdateHealth(float damagePoints)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossHit);
            Health -= damagePoints;

            // Indicate damage, or if health has reached 0, die
            if (Health < 0)
            {
                Sprites[CurrentSprite] = HurtSprites[CurrentSprite];
                Die();
            }
            else
            {
                if (!Injured)
                {
                    Sprites[CurrentSprite] = HurtSprites[CurrentSprite];
                }
                else
                {
                    Sprites[CurrentSprite] = Sprites[CurrentSprite];
                }
                Sprites[CurrentSprite].UpdatePos(Position);
                Injured = !Injured;
            }
        }

        public void ChangeDirection()
        {
            Random rand = new();
            int random = rand.Next(0, 4);
            Sprites[CurrentSprite].UnregisterSprite();
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
            Sprites[CurrentSprite].RegisterSprite();
            Collider.Pos = Position;
        }
        public void Update(GameTime gameTime)
        {
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
                    Direction *= -1;
                    Sprites[CurrentSprite].UpdatePos(Position);
                    Collider.Pos = Position;
                    ChangePosition();
                    IsColliding = false;
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (CurrentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        CurrentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        Sprites[CurrentSprite].flashing = true;
                        new Timer(1.0f, StopFlashing);
                    }
                }
            }
        }

        public void Stun() { }
        public void StopFlashing()
        {
            Sprites[CurrentSprite].flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, Width, Height);
            EnemyItemDrop.DropClassDItem(Center);
        }
    }
}
