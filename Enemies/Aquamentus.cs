using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private int Width = 24;
        private int Height = 32;
        private int FireballSpeed = 5;
        private float Health = 6.0f;
        public Vector2 Position { get; set; }
        private Vector2 Center;
        private int CycleCount = 0;
        private readonly int MaxCycles = 50;
        private int PosIncrement = 1;
        private float currentCooldown = 0.0f;
        public RectCollider Collider { get; private set; }
        public Aquamentus(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateAquamentusSprite();
            Sprite.UnregisterSprite();
            LevelMaster.AddUpdateable(this);
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
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            DropItem();
            LevelMaster.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void ChangePosition()
        {
            Vector2 newPosition = new(Position.X, Position.Y);
            
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement *= -1;
            }

            newPosition.X += PosIncrement;
            CycleCount++;

            Position = newPosition;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack()
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossScream1, 1.0f, 0.0f, 0.0f);
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
                SoundFactory.PlaySound(SoundFactory.getInstance().BossHit, 1.0f, 0.0f, 0.0f);
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
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
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
                    if (currentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
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