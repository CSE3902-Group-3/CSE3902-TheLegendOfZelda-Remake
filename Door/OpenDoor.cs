using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class OpenDoor : ICollidable, IDoor
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
                    IAnimatedSprite northFrame = spriteFactory.CreateNorthOpenDoorTopFrameSprite();
                    northFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, northFrame);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateEastOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X + wallSize/2, (int)pos.Y, wallSize/2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite eastFrame = spriteFactory.CreateEastOpenDoorTopFrameSprite();
                    eastFrame.UpdatePos(pos + new Vector2(64, 0));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, eastFrame);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateSouthOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize/2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite southFrame = spriteFactory.CreateSouthOpenDoorTopFrameSprite();
                    southFrame.UpdatePos(pos + new Vector2(0, 64));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, southFrame);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateWestOpenDoorSprite();
                    sprite.UpdatePos(pos);
                    collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize/2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite westFrame = spriteFactory.CreateWestOpenDoorTopFrameSprite();
                    westFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, westFrame);
                    break;
            }
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer == CollisionLayer.Player && !GameState.Link.StateMachine.isKnockedBack)
                {
                    player = GameState.Link;
                    player.StateMachine.prevDirection = player.StateMachine.currentDirection;
                    player.StateMachine.currentDirection = direction;
                    player.EnterRoomTransition();
                    LevelManager.GetInstance().TransitionToRoom(direction);
                    break;
                }
            }
        }
        public void Open(){}
        public void Close(){}
    }
}
