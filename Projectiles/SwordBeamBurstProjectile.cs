using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SwordBeamBurstProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private const float speed = 4;

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
        private RectCollider collider;

        private Timer timer;
        private const double delay = .5;
        public SwordBeamBurstProjectile(Vector2 position, Direction direction)
        {
            game = Game1.getInstance();
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            _pos = position;

            switch (direction)
            {
                case Direction.upLeft:
                    dir = new Vector2(-1, -1);
                    sprite = spriteFactory.CreateBeamProjectileUpLeftSprite();
                    break;
                case Direction.upRight:
                    dir = new Vector2(1, -1);
                    sprite = spriteFactory.CreateBeamProjectileUpRightSprite();
                    break;
                case Direction.downLeft:
                    dir = new Vector2(-1, 1);
                    sprite = spriteFactory.CreateBeamProjectileDownLeftSprite();
                    break;
                case Direction.downRight:
                    dir = new Vector2(1, 1);
                    sprite = spriteFactory.CreateBeamProjectileDownRightSprite();
                    break;
                default:
                    Debug.WriteLine("Invalid beam projectile direction");
                    break;
            }
            SoundFactory.PlaySound(SoundFactory.getInstance().SwordCombined, 1.0f, 0.0f, 0.0f);
            sprite.UpdatePos(position);

            int scale = spriteFactory.scale;
            collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, 8 * scale, 10 * scale), CollisionLayer.PlayerWeapon, this);

            LevelMaster.RegisterUpdateable(this);

            timer = new Timer(delay, Destroy);
        }

        public void Update(GameTime gameTime)
        {
            Pos += dir * speed;
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
            LevelMaster.RemoveCollider(collider);
            collider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            //Do nothing
        }
    }
}
