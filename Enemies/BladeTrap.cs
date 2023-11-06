using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BladeTrap : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        public Vector2 Position;
        public RectCollider Collider { get; private set; }
        public BladeTrap(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateBladeTrapSprite();

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn() {
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
        }
        public void UpdateHealth(float damagePoints) {}

        public void Attack() {}

        public void ChangePosition() {}

        public void ChangeDirection() {}
        public void Update(GameTime gameTime) {}

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                }
            }
        }
        public void DropItem() {}
    }
}
