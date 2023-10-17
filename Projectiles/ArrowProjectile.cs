using LegendOfZelda;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using static System.Formats.Asn1.AsnWriter;

namespace LegendOfZelda
{
    public class ArrowProjectile : IPlayerProjectile
    {
        protected AnimatedSprite sprite;
        protected SpriteFactory spriteFactory;

        private const float speed = 6;
        private Vector2 horizontalArrowBurstOffset;
        private Vector2 verticalArrowBurstOffset;

        private Vector2 _pos;
        protected Vector2 Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                sprite.UpdatePos(_pos);
                collider.Pos = _pos;
            }
        }

        protected Vector2 dir;
        protected RectCollider collider;

        public ArrowProjectile(Vector2 position, Direction direction)
        {
            spriteFactory = SpriteFactory.getInstance();
            _pos = position;

            int scale = spriteFactory.scale;

            horizontalArrowBurstOffset = new Vector2(4 * scale, -2 * scale);
            verticalArrowBurstOffset = new Vector2(-2 * scale, 4 * scale);

            CreateSpriteAndCollider(direction, scale);

            sprite.UpdatePos(position);

            LevelMaster.RegisterUpdateable(this);
        }

        protected virtual void CreateSpriteAndCollider(Direction direction, int scale)
        {
            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateArrowUpSprite();
                    dir = new Vector2(0, -1);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, 5 * scale, 16 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateArrowDownSprite();
                    dir = new Vector2(0, 1);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, 5 * scale, 16 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateArrowRightSprite();
                    dir = new Vector2(1, 0);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, 16 * scale, 5 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateArrowLeftSprite();
                    dir = new Vector2(-1, 0);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, 16 * scale, 5 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            Pos += dir * speed;
        }

        public void Destroy()
        {
            if (dir.X == 0)
            {
                new Burst(Pos + verticalArrowBurstOffset);
            }
            else
            {
                new Burst(Pos + horizontalArrowBurstOffset);
            }

            sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
            collider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer != CollisionLayer.Wall)
                {
                    Destroy();
                }
            }
        }
    }
}
