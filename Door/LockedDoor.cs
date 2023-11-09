using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LockedDoor : ICollidable
    {
        private IAnimatedSprite openSprite;
        private IAnimatedSprite closedSprite;

        public bool Closed { get; private set; }

        private IRectCollider closedCollider;
        private IRectCollider openCollider;

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
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateEastLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateSouthLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWestLockedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
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
            player = Game1.getInstance().link;
            //This call is long because Link's inventory is deeply nested in Link and because the RemoveItem method requires an actual IItem object
            if(player.stateMachine.linkInventory.RemoveItem(new Key(Vector2.Zero)) == true)
            {
                OpenDoor();
            }
        }

        private void HandlePlayerCollisionWhenUnlocked()
        {
            LevelMaster.GetInstance().NavigateInDirection(direction, OnNavComplete);
            player = Game1.getInstance().link;
            player.EnterRoomTransition();
        }

        public void OpenDoor()
        {
            openCollider.Active = true;
            openSprite.RegisterSprite();

            closedCollider.Active = false;
            closedSprite.UnregisterSprite();

            Closed = false;
        }

        private void OnNavComplete()
        {
            player.ExitRoomTransition();
        }
    }
}
