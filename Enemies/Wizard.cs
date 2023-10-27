using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
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
            new FireProjectile(Position, Direction.left);
            new FireProjectile(Position, Direction.down);
            new FireProjectile(Position, Direction.up);
        }
        public void UpdateHealth(int damagePoints) {}

        public void ChangeDirection() {}
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
        }

        public void Update(GameTime gameTime) {}

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;
                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                    Attack();
                }
            }
        }
        public void DropItem()
        {
            StateMachine.DropItem();
        }
    }
}
