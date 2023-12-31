﻿using Microsoft.Xna.Framework;
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
        private const int colliderWidth = 8;
        private const int colliderHeight = 10;

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
            SoundFactory.PlaySound(SoundFactory.getInstance().SwordCombined);
            sprite.UpdatePos(position);

            int scale = spriteFactory.scale;
            collider = new RectCollider(new Rectangle((int)_pos.X, (int)_pos.Y, colliderWidth * scale, colliderHeight * scale), CollisionLayer.PlayerWeapon, this);

            LevelManager.AddUpdateable(this);
            LevelManager.CurrentLevelRoom.AddProjectile(this);
            timer = new Timer(delay, Destroy);
        }

        public void Update(GameTime gameTime)
        {
            Pos += dir * speed;
        }

        public void Destroy()
        {
            LevelManager.CurrentLevelRoom.RemoveProjectile(this);
            LevelManager.RemoveUpdateable(this);
            sprite.UnregisterSprite();
            collider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            //Do nothing
        }
    }
}
