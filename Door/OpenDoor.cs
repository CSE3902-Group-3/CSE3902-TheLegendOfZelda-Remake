using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class OpenDoor : ICollidable
    {
        private IAnimatedSprite sprite;
        private IRectCollider collider;
        private Direction direction;
        private IPlayer player;

        private int wallSize = 32;
        public OpenDoor(Vector2 pos, Direction direction)
        {
            this.direction = direction;
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            wallSize *= spriteFactory.scale;

            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateNorthOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize/2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateEastOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X + wallSize/2, (int)pos.Y, wallSize/2, wallSize), CollisionLayer.OuterWall, this);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateSouthOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize/2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateWestOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize/2, wallSize), CollisionLayer.OuterWall, this);
                    break;
            }
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    player = GameState.Link;
                    player.EnterRoomTransition();
                    LevelMaster.GetInstance().TransitionToRoom(direction);
                    break;
                }
            }
        }
    }
}
