using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class AquamentusBall : IEnemyProjectile
    {
        private readonly AnimatedSprite Sprite;
        private Vector2 Direction;
        private Vector2 Position;
        private Vector2 Offset = new Vector2(0, 12);
        public RectCollider Collider { get; private set; }
        public AquamentusBall(Vector2 pos, Vector2 dir)
        {
            LevelManager.AddUpdateable(this);
            SoundFactory.PlaySound(SoundFactory.getInstance().ArrowBoomerang);
            Sprite = SpriteFactory.getInstance().CreateAquamentusBallSprite();
            Position = pos;
            Direction = dir;

            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X + (int)Offset.X, (int)Position.Y + (int)Offset.Y, 8 * scale, 10 * scale),
               CollisionLayer.EnemyWeapon,
               this
           );
            Collider.Active = true;
        }
        public void Update(GameTime gameTime)
        {
            Position += Direction;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position + Offset;
        }
        public void Destroy()
        {
            new AquamentusBallExplosion(Position);
            Collider.Active = false;
            LevelManager.RemoveUpdateable(this);
            LevelManager.RemoveDrawable(Sprite);
            Collider.Active = false;
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
