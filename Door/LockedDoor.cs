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
            LevelManager.CurrentLevelRoom.AddDoor(direction, this);

            switch (direction)
            {
                case Direction.up:
                    openSprite = spriteFactory.CreateNorthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateNorthLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateEastLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateSouthLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWestLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    OpenCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
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
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
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
