using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LegendOfZelda
{
    public class FireProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
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
        private bool moving = true;
        private const double moveDelay = 2;
        private const double haltDelay = 1;
        private Timer timer;
        private RectCollider collider;

        private const int fireWidth = 16;

        public FireProjectile(Vector2 position, Direction direction)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            _pos = position;

            switch (direction)
            {
                case Direction.up:
                    dir = new Vector2(0, -1);
                    break;
                case Direction.down:
                    dir = new Vector2(0, 1);
                    break;
                case Direction.right:
                    dir = new Vector2(1, 0);
                    break;
                case Direction.left:
                    dir = new Vector2(-1, 0);
                    break;
            }

            sprite = spriteFactory.CreateFireSprite();
            sprite.UpdatePos(position);

            int scale = spriteFactory.scale;
            collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, fireWidth * scale, fireWidth * scale), CollisionLayer.PlayerWeapon, this);

            timer = new Timer(moveDelay, StopMoving);

            LevelMaster.RegisterUpdateable(this);
        }

        //Could benefit from a state machine, but it would be overkill
        public void Update(GameTime gameTime)
        {
            if (moving)
            {
                Pos += dir * speed;
            }
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
            collider.Active = false;
            LevelMaster.RemoveUpdateable(this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer == CollisionLayer.Wall || collision.CollidedWith.Layer == CollisionLayer.OuterWall)
                {
                    Pos = CollisionManager.PosSnappedToEdge(collision.EstimatedDirection, collision.OverlapRectangle, Pos);
                }
            }
        }

        private void StopMoving()
        {
            moving = false;
            timer = new Timer(haltDelay, Destroy);
        }
    }
}

