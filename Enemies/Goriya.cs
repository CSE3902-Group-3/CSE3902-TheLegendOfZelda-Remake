using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Goriya : IEnemy
    {
        private readonly List<AnimatedSprite> Sprites;
        private int CurrentSprite;
        public AnimatedSprite Sprite { get; set; }
        public float Health { get; set; } = 3.0f;
        public int Width { get; }
        public int Height { get; }
        public Type EnemyType { get; set; }
        public EnemyItemDrop.EnemyClass Classification { get; } = EnemyItemDrop.EnemyClass.C;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new(1, 0);
        public Vector2 Offset { get; set; } = new(0, 0);
        public RectCollider Collider { get; }
        public bool IsColliding { get; set; } = false;
        public bool Frozen { get; set; } = false;

        public bool AllowedToMove { get; set; } = true;
        public Vector2 SpeedMultiplier { get; set; } = new(1, 1);
        public float CurrentCooldown { get; set; } = 0.0f;
        public double LastSwitch { get; set; } = 0;
        private Vector2 Center;
        private int UpdateCount = 0;
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
            LevelManager.AddUpdateable(this);

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
            if (!Frozen && AllowedToMove)
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
                SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
                //Sprites[CurrentSprite].blinking = true;
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
        }
        public void Update(GameTime gameTime)
        {
            CurrentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
            if (!Frozen)
            {
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
                Collider.Pos = Position;
            }
        }
        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    Direction *= -1;
                    Sprites[CurrentSprite].UpdatePos(Position);
                    Collider.Pos = Position;
                    ChangePosition();
                    Direction *= -1;
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (CurrentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        CurrentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        for(int i = 0; i < Sprites.Count; i++)
                        {
                            Sprites[i].flashing = true;
                        }
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
            for (int i = 0; i < Sprites.Count; i++)
            {
                Sprites[i].flashing = false;
            }
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, 16, 16);
            EnemyItemDrop.DropClassBItem(Center);
        }
    }
}
