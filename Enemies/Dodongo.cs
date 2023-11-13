using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Dodongo : IEnemy
    {
        private readonly List<AnimatedSprite> Sprites;
        private readonly List<AnimatedSprite> HurtSprites;
        private int CurrentSprite;
        private float Health { get; set; } = 8.0f;
        public Vector2 Position { get; set; }
        private Vector2 Center;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private int UpdateCount = 0;
        private bool Injured = false;
        private float currentCooldown = 0.0f;
        public bool isColliding = false;
        public RectCollider Collider { get; private set; }
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

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossScream2, 1.0f, 0.0f, 0.0f);
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprites[CurrentSprite].RegisterSprite();
            Sprites[CurrentSprite].UpdatePos(Position);
            Collider.Pos = Position;
            Collider.Active = true;
        }
        public void ChangePosition()
        {
            Position += Direction;
            Sprites[CurrentSprite].UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack() { }
        public void UpdateHealth(float damagePoints)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossHit, 1.0f, 0.0f, 0.0f);
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
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000 && isColliding == false)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                UpdateCount++;

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
                    isColliding = true;
                    Direction *= -1;
                    Sprites[CurrentSprite].UpdatePos(Position);
                    Collider.Pos = Position;
                    ChangePosition();
                    isColliding = false;
                    ChangeDirection();
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

        public void Stun() { }
        public void StopFlashing()
        {
            Sprites[CurrentSprite].flashing = false;
        }
        public void DropItem()
        {
            Center = EnemyUtilities.GetCenter(Position, 16, 16);
            EnemyItemDrop.DropClassDItem(Center);
        }
    }
}
