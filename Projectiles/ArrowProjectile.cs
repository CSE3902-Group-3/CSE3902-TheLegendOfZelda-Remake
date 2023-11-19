using LegendOfZelda;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class ArrowProjectile : IPlayerProjectile
    {
        protected AnimatedSprite sprite;
        protected SpriteFactory spriteFactory;

        private const float speed = 8;
        private Vector2 horizontalArrowBurstOffset;
        private Vector2 verticalArrowBurstOffset;

        private const int horizontalArrowBurstOffsetX = 4;
        private const int horizontalArrowBurstOffsetY = -2;
        private const int verticalArrowBurstOffsetX = -2;
        private const int verticalArrowBurstOffsetY = 4;
        protected const int arrowWidth = 16;
        protected const int arrowHeight = 5;

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

            horizontalArrowBurstOffset = new Vector2(horizontalArrowBurstOffsetX * scale, horizontalArrowBurstOffsetY * scale);
            verticalArrowBurstOffset = new Vector2(verticalArrowBurstOffsetX * scale, verticalArrowBurstOffsetY * scale);

            CreateSpriteAndCollider(direction, scale);

            sprite.UpdatePos(position);

            LevelMaster.RegisterUpdateable(this);
        }

        //This method is overridden in the Blue Arrow and Sword Beam
        protected virtual void CreateSpriteAndCollider(Direction direction, int scale)
        {
            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateArrowUpSprite();
                    dir = new Vector2(0, -1);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, arrowHeight * scale, arrowWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateArrowDownSprite();
                    dir = new Vector2(0, 1);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, arrowHeight * scale, arrowWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateArrowRightSprite();
                    dir = new Vector2(1, 0);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, arrowWidth * scale, arrowHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateArrowLeftSprite();
                    dir = new Vector2(-1, 0);
                    collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, arrowWidth * scale, arrowHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
            }
            SoundFactory.PlaySound(SoundFactory.getInstance().ArrowBoomerang);
        }

        public void Update(GameTime gameTime)
        {
            Pos += dir * speed;
        }

        //This method is overridden in the Sword Beam
        protected virtual void SpawnBurst()
        {
            if (dir.X == 0)
            {
                new Burst(Pos + verticalArrowBurstOffset);
            }
            else
            {
                new Burst(Pos + horizontalArrowBurstOffset);
            }
        }

        public void Destroy()
        {
            SpawnBurst();

            sprite.UnregisterSprite();
            LevelMaster.RemoveUpdateable(this);
            collider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                CollisionLayer layer = collision.CollidedWith.Layer;
                if (layer == CollisionLayer.OuterWall || layer == CollisionLayer.Enemy)
                {
                    Destroy();
                }
            }
        }
    }
}
