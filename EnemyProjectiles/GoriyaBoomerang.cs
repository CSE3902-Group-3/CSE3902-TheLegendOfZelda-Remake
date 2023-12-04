using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class GoriyaBoomerang : IEnemyProjectile
    {
        private readonly AnimatedSprite Sprite;
        private Vector2 Direction;
        private Vector2 Position;
        public RectCollider Collider { get; private set; }
        public GoriyaBoomerang(Vector2 pos, Vector2 dir)
        {
            LevelManager.CurrentLevelRoom.AddProjectile(this);
            LevelManager.AddUpdateable(this);
            SoundFactory.PlaySound(SoundFactory.getInstance().ArrowBoomerang);
            Sprite = SpriteFactory.getInstance().CreateBoomerangSprite();
            Position = pos;
            Direction = dir;

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 8 * scale, 8 * scale),
               CollisionLayer.EnemyWeapon,
               this
           );
            Collider.Active = true;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
        public void Destroy()
        {
            LevelManager.CurrentLevelRoom.RemoveProjectile(this);
            new Burst(Position);
            SoundFactory.PlaySound(SoundFactory.getInstance().SwordSlash);
            Collider.Active = false;
            LevelManager.RemoveUpdateable(this);
            LevelManager.RemoveDrawable(Sprite);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Player || collidedWith == CollisionLayer.PlayerWeapon)
                {
                    Destroy();
                }
            }
        }
    }
}
