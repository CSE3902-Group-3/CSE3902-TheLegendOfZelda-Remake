using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wall : ICollidable
    {
        private IAnimatedSprite sprite;
        private IRectCollider collider;

        private int wallSize = 32;
        public Wall(Vector2 pos, Direction direction)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            wallSize *= spriteFactory.scale;

            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateWallNorthSprite();
                    sprite.UpdatePos(pos);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateWallEastSprite();
                    sprite.UpdatePos(pos);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateWallSouthSprite();
                    sprite.UpdatePos(pos);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateWallWestSprite();
                    sprite.UpdatePos(pos);
                    break;
            }

            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize), CollisionLayer.OuterWall, this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
           //Do nothing
        }
    }
}
