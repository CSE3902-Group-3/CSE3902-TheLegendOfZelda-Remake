using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Rope : IEnemy
    {
        private AnimatedSprite Sprite;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        private readonly int PosIncrement = 5;
        private bool FacingLeft = false;
        private double LastSwitch = 0;
        public RectCollider Collider { get; private set; }
        public Rope(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)this.Position.X, (int)+this.Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            LevelMaster.RegisterUpdateable(this);
            Sprite.RegisterSprite();
            Sprite.UpdatePos(Position);
        }
        public void ChangePosition()
        {
            // Cycle left and right movement
            if (FacingLeft)
            {
                Position.X -= PosIncrement;
            }
            else
            {
                Position.X += PosIncrement;
            }

            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Attack() {}
        public void UpdateHealth(int damagePoints) {}

        public void ChangeDirection()
        {
            LevelMaster.RemoveDrawable(Sprite);
            if (FacingLeft)
            {
                Sprite = SpriteFactory.getInstance().CreateRopeRightSprite();
            }
            else
            {
                Sprite = SpriteFactory.getInstance().CreateRopeLeftSprite();
            }
            FacingLeft = !FacingLeft;
            Collider.Pos = Position;
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastSwitch + 1000)
            {
                LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection();
            }
            ChangePosition();
        }
        public void Die()
        {
            Sprite.UpdatePos(Position);
            Sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
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
    }
}
