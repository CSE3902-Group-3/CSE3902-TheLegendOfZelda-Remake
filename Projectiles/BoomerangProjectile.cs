using LegendOfZelda;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BoomerangProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private IRectCollider collider;

        private SpriteFactory spriteFactory;
        private float speed = 15;
        private const float accel = .25f;

        private Vector2 _pos;
        private Vector2 Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                sprite.UpdatePos(_pos);
                collider.Pos = _pos;
            }
        }

        private Vector2 dir;
        private bool returning = false;
        private IPlayer player;

        private const int boomerangWidth = 8;

        public BoomerangProjectile(Vector2 position, Vector2 direction, IPlayer player)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            _pos = position;
            this.player = player;

            dir = direction;
            dir.Normalize();

            sprite = spriteFactory.CreateBoomerangSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().ArrowBoomerang, 1.0f, 0.0f, 0.0f);
            sprite.UpdatePos(position);

            int scale = spriteFactory.scale;
            collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, boomerangWidth * scale, boomerangWidth * scale), CollisionLayer.PlayerWeapon, this);

            LevelManager.AddUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            //State pattern would work better here but would be overkill for such a small class
            if (returning)
            {
                dir = player.Pos - Pos;
                if(dir.Length() < speed)
                {
                    Destroy();
                }
                else
                {
                    dir.Normalize();
                    Pos += dir * speed;
                    speed += accel;
                }
            }
            else
            {
                if (speed <= 0){
                    returning = true;
                } else
                {
                    Pos += speed * dir;
                    speed -= accel;
                }
            }
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
            collider.Active = false;
            LevelManager.RemoveUpdateable(this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            //Separating this logic into separate classes would be overkill here
            foreach(CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    Destroy();
                } else if(collision.CollidedWith.Layer == CollisionLayer.Enemy)
                {
                    returning = true;
                }
            }
        }
    }
}
