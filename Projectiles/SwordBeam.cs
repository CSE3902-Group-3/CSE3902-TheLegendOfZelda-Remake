using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SwordBeam : ArrowProjectile
    {
        private const int beamColliderHeight = 7;
        private const int beamColliderWidth = 16;

        public SwordBeam(Vector2 position, Direction direction) : base(position, direction) { }

        protected override void CreateSpriteAndCollider(Direction direction, int scale)
        {
            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateSwordBeamUpSprite();
                    dir = new Vector2(0, -1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, beamColliderHeight * scale, beamColliderWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateSwordBeamDownSprite();
                    dir = new Vector2(0, 1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, beamColliderHeight * scale, beamColliderWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateSwordBeamRightSprite();
                    dir = new Vector2(1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, beamColliderWidth * scale, beamColliderHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateSwordBeamLeftSprite();
                    dir = new Vector2(-1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, beamColliderWidth * scale, beamColliderHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
            }
            SoundFactory.PlaySound(SoundFactory.getInstance().SwordShoot);
        }

        protected override void SpawnBurst()
        {
            new SwordBeamBurstProjectile(Pos, Direction.upLeft);
            new SwordBeamBurstProjectile(Pos, Direction.upRight);
            new SwordBeamBurstProjectile(Pos, Direction.downLeft);
            new SwordBeamBurstProjectile(Pos, Direction.downRight);
        }
    }
}
