using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private int Width = 18;
        private int Height = 18;
        private readonly AnimatedSprite Sprite;
        private float Health { get; set; } = 1.0f;
        public Vector2 Position { get; set; }
        private float currentCooldown = 0.0f;
        public RectCollider Collider { get; private set; }

        public Wizard(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateOldManSprite();
            Sprite.UpdatePos(pos);
            Sprite.UnregisterSprite();
            LevelMaster.RegisterUpdateable(this);
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
        public void Die() { }
        public void ChangePosition() { }
        public void Attack()
        {
            // Mechanics of this attack can be changed later
            new FireProjectile(Position, Direction.right);
        }
        public void UpdateHealth(float damagePoints)
        {
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
            Sprite.flashing = true;
        }

        public void ChangeDirection() { }

        public void Update(GameTime gameTime)
        {
            currentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;
                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (currentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                    }
                }
            }
        }
        public void Stun() { }
        public void DropItem() { }
    }
}
