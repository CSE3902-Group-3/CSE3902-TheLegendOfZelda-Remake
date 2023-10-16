using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BladeTrap : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        public Vector2 Position;

        public BladeTrap(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateBladeTrapSprite();
        }
        public void Spawn() {
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
        }
        public void UpdateHealth(int damagePoints) {}

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
    }
}
