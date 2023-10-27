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
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private Vector2 Direction;
        private double LastSwitch = 0;
        private int UpdateCount = 0;
        private bool Injured = false;
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
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprites[CurrentSprite].RegisterSprite();
            Sprites[CurrentSprite].UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void ChangePosition()
        {
            Position += Direction;
            if (Position.X < 0 || Position.Y < 0)
            {
                Position -= Direction;
            }

            Sprites[CurrentSprite].UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack() {}
        public void UpdateHealth(int damagePoints)
        {
            Sprites[CurrentSprite].UnregisterSprite();
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
            Sprites[CurrentSprite].UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
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
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                }
            }
        }
        public void DropItem()
        {
            EnemyItemDrop.Drop();
        }
    }
}
