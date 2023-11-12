﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LegendOfZelda
{
    public class Staircase : ICollidable
    {
        private IAnimatedSprite sprite;
        private IRectCollider collider;
        private Vector2 entrancePosition;
        private IPlayer player;

        private int doorSize = 16;
        public Staircase(Vector2 pos)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();

            int scale = spriteFactory.scale;
            doorSize *= scale;

            sprite = spriteFactory.CreateStairsSprite();
            sprite.UpdatePos(pos);
            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, doorSize, doorSize), CollisionLayer.Wall, this);

            entrancePosition = new Vector2(304 * scale, -608 * scale);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    LevelMaster.GetInstance().NavigateToRoom(LevelMaster.brickRoom);

                    player = GameState.Link;
                    if(player is Link)
                    {
                        LinkUtilities.UpdatePositions(player as Link, entrancePosition);
                    }
                    break;
                }
            }
        }
    }
}
