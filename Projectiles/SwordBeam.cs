using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Projectiles
{
    public class SwordBeam : ArrowProjectile
    {
        public SwordBeam(Vector2 position, Direction direction) : base(position, direction) { }

        protected override void CreateSpriteAndCollider(Direction direction, int scale)
        {
            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateSwordBeamUpSprite();
                    dir = new Vector2(0, -1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, 7 * scale, 16 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateSwordBeamDownSprite();
                    dir = new Vector2(0, 1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, 7 * scale, 16 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateSwordBeamRightSprite();
                    dir = new Vector2(1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, 16 * scale, 7 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateSwordBeamLeftSprite();
                    dir = new Vector2(-1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, 16 * scale, 7 * scale), CollisionLayer.PlayerWeapon, this);
                    break;
            }
            SoundFactory.PlaySound(SoundFactory.getInstance().SwordShoot , 1.0f, 0.0f, 0.0f);
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
