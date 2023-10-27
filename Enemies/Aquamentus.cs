using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Aquamentus : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private float Health = 6.0f;
        private Vector2 Position;
        private int CycleCount = 0;
        private readonly int MaxCycles = 50;
        private int PosIncrement = 2;
        private float currentCooldown = 0.0f;
        public RectCollider Collider { get; private set; }
        public Aquamentus(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateAquamentusSprite();

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 24 * scale, 32 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn ()
        {
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (CycleCount > MaxCycles)
            {
                CycleCount = 0;
                PosIncrement = (int)(PosIncrement * -0.5);
            }
            Position.X += PosIncrement;
            CycleCount++;

            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack()
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossScream1, 1.0f, 0.0f, 0.0f);
            new AquamentusBall(Position, new Vector2(-10, 0));
            new AquamentusBall(Position, new Vector2(-10, 10));
            new AquamentusBall(Position, new Vector2(-10, -10));
        }
        public void UpdateHealth(float damagePoints)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().BossHit, 1.0f, 0.0f, 0.0f);
            Health -= damagePoints;

            // Indicate damage, or if health has reached 0, die
            if (Health < 0)
            {
                Die();
            }
            else
            {
                Sprite.blinking = true;
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
        public void Die()
        {
            Sprite.UpdatePos(Position);
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
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
                        UpdateHealth(1.0f); // Choose different values for each type of player weapon
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                    }
                }
            }
        }
    }
}
