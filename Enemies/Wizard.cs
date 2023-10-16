using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private readonly Game1 Game;
        private readonly AnimatedSprite Sprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;

        public Wizard(Vector2 pos)
        {
            Game = Game1.getInstance();
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateOldManSprite();
        }
        public void Spawn()
        {
            Game.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void ChangePosition() {}
        public void Attack()
        {
            // Mechanics of this attack can be changed later
            new FireProjectile(Position, Direction.right);
            new FireProjectile(Position, Direction.left);
            new FireProjectile(Position, Direction.down);
            new FireProjectile(Position, Direction.up);
        }
        public void UpdateHealth(int damagePoints) {}

        public void ChangeDirection() {}
        public void Die()
        {
            Sprite.UnregisterSprite();
            Game.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime) {}

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
                    UpdateHealth(1); // Choose different values for each type of player weapon
                    Attack();
                }
            }
        }
    }
}
