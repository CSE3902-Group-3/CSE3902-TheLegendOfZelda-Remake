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

        private const int exitPosX = 320;
        private const int exitPosY = -704;

        public LadderDoor(Vector2 pos)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            int scale = spriteFactory.scale;
            doorSize *= scale;

            sprite = spriteFactory.CreateBlackTileSprite();
            sprite.UpdatePos(pos);
            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, doorSize, doorSize), CollisionLayer.Wall, this);

            exitPos = new Vector2(exitPosX * scale, exitPosY * scale);
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
