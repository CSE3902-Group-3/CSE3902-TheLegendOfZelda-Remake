using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BombableDoor : ICollidable, IDoor
    {
        private IAnimatedSprite openSprite;
        private IAnimatedSprite closedSprite;

        public bool Closed { get; private set; }

        private IRectCollider closedCollider;
        private IRectCollider openCollider;

        private int wallSize = 32;
        private Direction direction;
        public BombableDoor(Vector2 pos, Direction direction)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            wallSize *= spriteFactory.scale;
            Closed = true;
            this.direction = direction;

            switch (direction)
            {
                case Direction.up:
                    openSprite = spriteFactory.CreateNorthHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallNorthSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite northFrame = spriteFactory.CreateNorthHoleDoorTopFrameSprite();
                    northFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, northFrame);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallEastSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite eastFrame = spriteFactory.CreateEastHoleDoorTopFrameSprite();
                    eastFrame.UpdatePos(pos + new Vector2(64, 0));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, eastFrame);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallSouthSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite southFrame = spriteFactory.CreateSouthHoleDoorTopFrameSprite();
                    southFrame.UpdatePos(pos + new Vector2(0, 64));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, southFrame);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallWestSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite westFrame = spriteFactory.CreateWestHoleDoorTopFrameSprite();
                    westFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, westFrame);
                    break;
            }

            closedCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize), CollisionLayer.OuterWall, this);
            openSprite.UnregisterSprite();
            openCollider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if (Closed) HandleCollisionWhenLocked(collision);
                else HandleCollisionWhenUnlocked(collision);
            }
        }
        private void HandleCollisionWhenLocked(CollisionInfo collision)
        {
            if(collision.CollidedWith.Collidable is Explosion)
            {
                Open();
            }
        }

        private void HandleCollisionWhenUnlocked(CollisionInfo collision)
        {
            if (collision.CollidedWith.Layer != CollisionLayer.Player && GameState.Link.StateMachine.isKnockedBack) return;
            GameState.Link.StateMachine.prevDirection = GameState.Link.StateMachine.currentDirection;
            GameState.Link.StateMachine.currentDirection = direction;
            GameState.Link.EnterRoomTransition();
            LevelManager.GetInstance().TransitionToRoom(direction);
        }

        public void Open()
        {
            openCollider.Active = true;
            openSprite.RegisterSprite();

            closedCollider.Active = false;
            closedSprite.UnregisterSprite();

            Closed = false;
        }
        public void Close()
        {
            openCollider.Active = false;
            openSprite.UnregisterSprite();

            closedCollider.Active = true;
            closedSprite.RegisterSprite();

            Closed = true;
        }
    }
}
