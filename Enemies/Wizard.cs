using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private float Health { get; set; } = 1.0f;
        public Vector2 Position;
        private float currentCooldown = 0.0f;
        public RectCollider Collider { get; private set; }

        public Wizard(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateOldManSprite();
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 18 * scale, 18 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            LevelMaster.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void ChangePosition() {}
        public void Attack()
        {
            // Mechanics of this attack can be changed later
            new FireProjectile(Position, Direction.right);
        }

        public void UpdateHealth(int damagePoints) {
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit, 1.0f, 0.0f, 0.0f);
        }

        public void ChangeDirection() {}
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
        }

        public void Update(GameTime gameTime) {
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
                        UpdateHealth(1.0f); // Choose different values for each type of player weapon
                        currentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                    }
                }
            }
        }
    }
}
