using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private readonly List<AnimatedSprite> Sprites;
        private int CurrentSprite;
        private float Health { get; set; } = 3.0f;
        public Vector2 Position;
        private Vector2 Center;
        private Vector2 Direction = new Vector2(1, 0);
        private double LastSwitch = 0;
        private int UpdateCount = 0;
        private float currentCooldown = 0.0f;
        private bool allowedToMove = true;
        public RectCollider Collider { get; private set; }
        public Goriya(Vector2 pos)
        {
            Position = pos;
            Sprites = new List<AnimatedSprite>
            {
                SpriteFactory.getInstance().CreateGoriyaRightSprite(),
                SpriteFactory.getInstance().CreateGoriyaLeftSprite(),
                SpriteFactory.getInstance().CreateGoriyaDownSprite(),
                SpriteFactory.getInstance().CreateGoriyaUpSprite()
            };

            foreach (AnimatedSprite goriya in Sprites)
            {
                goriya.UnregisterSprite();
            }

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprites[CurrentSprite].RegisterSprite();
            Sprites[CurrentSprite].UpdatePos(Position);
            Collider.Active = true;
        }
        public void ChangePosition()
        {
            if (allowedToMove)
            {
                Position += Direction;
                Sprites[CurrentSprite].UpdatePos(Position);
                Collider.Pos = Position;
            }
        }
        public void Attack()
        {
            new GoriyaBoomerang(Position, Direction * 3);
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
                Sprites[CurrentSprite].blinking = true;
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
        public void Die()
        {
            Sprites[CurrentSprite].UpdatePos(Position);
            Sprites[CurrentSprite].UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
        }

        public void Update(GameTime gameTime)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                UpdateCount++;

                ChangeDirection();

                if (UpdateCount % 2 == 0)
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

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    Direction = -Direction;
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (currentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        Sprites[CurrentSprite].flashing = true;
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
            Sprites[CurrentSprite].flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, 16, 16);
            EnemyItemDrop.DropClassBItem(Center);
        }
    }
}
