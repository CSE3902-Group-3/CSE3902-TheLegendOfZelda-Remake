using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class SpikeTrap : IEnemy
    {
        private readonly AnimatedSprite Sprite;
        private int Width = 16;
        private int Height = 16;
        public Vector2 Position { get; set; }
        public Vector2 Direction;
        public RectCollider Collider { get; private set; }
        private bool isMoving = false;
        public SpikeTrap(Vector2 pos)
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

        public void Attack() {
            Vector2 linkPosition = GameState.Link.Pos;
            bool detectingLink = (linkPosition.X == Position.X || linkPosition.Y == Position.Y);

            if (detectingLink)
            {
                if (linkPosition.X == Position.X && linkPosition.Y > Position.Y)
                {
                    Direction = new Vector2(0, 1);
                }
                else if (linkPosition.X == Position.X && linkPosition.Y < Position.Y)
                {
                    Direction = new Vector2(0, -1);
                }
                else if (linkPosition.Y == Position.Y && linkPosition.X > Position.X)
                {
                    Direction = new Vector2(1, 0);
                }
                else if (linkPosition.Y == Position.Y && linkPosition.X < Position.X)
                {
                    Direction = new Vector2(-1, 0);
                }
                else // Return to the original position
                {

                }
                isMoving = true;
            }
            ChangePosition();
        }

        public void ChangePosition() {
            if (isMoving)
            {
                Position += Direction * 5;
                Sprite.UpdatePos(Position);
                Collider.Pos = Position;
            }
        }

        public void ChangeDirection() { }
        public void Update(GameTime gameTime) {
            Attack();
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                }
                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    Direction = new Vector2(0, 0);
                }
                if (collidedWith == CollisionLayer.Player)
                {
                    isMoving = false;
                }
            }
        }
        public void Stun() { }
        public void DropItem() { }
    }
}
