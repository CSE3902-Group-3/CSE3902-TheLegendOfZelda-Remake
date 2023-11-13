using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LadderDoor : ICollidable
    {
        private IAnimatedSprite sprite;
        private IRectCollider collider;
        private IPlayer player;
        private Vector2 exitPos;

        private int doorSize = 16;
        public LadderDoor(Vector2 pos)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            int scale = spriteFactory.scale;
            doorSize *= scale;

            sprite = spriteFactory.CreateBlackTileSprite();
            sprite.UpdatePos(pos);
            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, doorSize, doorSize), CollisionLayer.Wall, this);

            exitPos = new Vector2(320 * scale, -704 * scale);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    LevelMaster.GetInstance().NavigateToRoom(LevelMaster.brickRoomEntrance);

                    player = GameState.Link;
                    if (player is Link)
                    {
                        LinkUtilities.UpdatePositions(player as Link, exitPos);
                    }
                    break;
                }
            }
        }
    }
}
