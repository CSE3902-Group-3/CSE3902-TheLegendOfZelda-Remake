using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BladeTrap : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private int Width = 16;
        private int Height = 16;
        public Vector2 Position { get; set; }
        public RectCollider Collider { get; private set; }
        public BladeTrap(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateBladeTrapSprite();
            Sprite.UnregisterSprite();
            LevelManager.AddUpdateable(this);
            Sprite.UpdatePos(pos);
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
            LevelManager.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void UpdateHealth(float damagePoints) { }

        public void Attack() { }

        public void ChangePosition() { }

        public void ChangeDirection() { }
        public void Update(GameTime gameTime) {}

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                }
            }
        }
        public void Stun() { }
        public void DropItem() { }
    }
}
