using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class BlueArrowProjectile : ArrowProjectile
    {
        public BlueArrowProjectile(Vector2 position, Direction direction) : base(position, direction) { }

        protected override void CreateSpriteAndCollider(Direction direction, int scale)
        {
            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateBlueArrowUpSprite();
                    dir = new Vector2(0, -1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, arrowHeight * scale, arrowWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateBlueArrowDownSprite();
                    dir = new Vector2(0, 1);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, arrowHeight * scale, arrowWidth * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateBlueArrowRightSprite();
                    dir = new Vector2(1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, arrowWidth * scale, arrowHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateBlueArrowLeftSprite();
                    dir = new Vector2(-1, 0);
                    collider = new RectCollider(new Rectangle((int)Pos.X, (int)Pos.Y, arrowWidth * scale, arrowHeight * scale), CollisionLayer.PlayerWeapon, this);
                    break;
            }
        }
    }
}
