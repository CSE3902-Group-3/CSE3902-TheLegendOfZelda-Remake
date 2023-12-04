using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LockedDoor : ICollidable, IDoor
    {
        private IAnimatedSprite openSprite;
        private IAnimatedSprite closedSprite;

        public bool Closed { get; private set; }

        public IRectCollider ClosedCollider { get; private set; }
        public IRectCollider OpenCollider { get; private set; }

        private int wallSize = 32;
        private IPlayer player;
        private Direction direction;
        public LockedDoor(Vector2 pos, Direction direction)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            wallSize *= spriteFactory.scale;
            Closed = true;
            this.direction = direction;

            switch (direction)
            {
                case Direction.up:
                    openSprite = spriteFactory.CreateNorthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateNorthLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite northFrame = spriteFactory.CreateNorthOpenDoorTopFrameSprite();
                    northFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, northFrame);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateEastLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite eastFrame = spriteFactory.CreateEastOpenDoorTopFrameSprite();
                    eastFrame.UpdatePos(pos + new Vector2(64, 0));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, eastFrame);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateSouthLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite southFrame = spriteFactory.CreateSouthOpenDoorTopFrameSprite();
                    southFrame.UpdatePos(pos + new Vector2(0, 64));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, southFrame);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWestLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite westFrame = spriteFactory.CreateWestOpenDoorTopFrameSprite();
                    westFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, westFrame);
                    break;
            }

            ClosedCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize), CollisionLayer.OuterWall, this);
            openSprite.UnregisterSprite();
            OpenCollider.Active = false;
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player && !GameState.Link.StateMachine.isKnockedBack)
                {
                    if (Closed) HandlePlayerCollisionWhenLocked();
                    else HandlePlayerCollisionWhenUnlocked();
                    break;
                }
            }
        }

        private void HandlePlayerCollisionWhenLocked()
        {
            player = GameState.Link;
            //This call is long because Link's inventory is deeply nested in Link and because the RemoveItem method requires an actual IItem object
            if(player.StateMachine.linkInventory.RemoveItem(new Key(Vector2.Zero)) == true)
            {
                Open();
            }
        }

        private void HandlePlayerCollisionWhenUnlocked()
        {
            LevelManager.GetInstance().TransitionToRoom(direction);
            player = GameState.Link;
            player.StateMachine.prevDirection = player.StateMachine.currentDirection;
            player.StateMachine.currentDirection = direction;
            player.EnterRoomTransition();
        }

        public void Open()
        {
            if (Closed)
            {
                openSprite.RegisterSprite();
                LevelManager.RemoveDrawable(closedSprite);
                ClosedCollider.Active = false;
                OpenCollider.Active = true;
                Closed = false;
                SoundFactory.PlaySound(SoundFactory.getInstance().DoorUnlock);
            }
        }
        public void Close()
        {
            if (!Closed)
            {
                OpenCollider.Active = false;
                openSprite.UnregisterSprite();

                ClosedCollider.Active = true;
                closedSprite.RegisterSprite();

                Closed = true;
            }
        }
    }
}
