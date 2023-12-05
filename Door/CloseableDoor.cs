using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class CloseableDoor : ICollidable, IDoor
    {
        private IAnimatedSprite openSprite;
        private IAnimatedSprite closedSprite;

        public bool Closed { get; private set; }

        private IRectCollider closedCollider;
        private IRectCollider openCollider;

        private int wallSize = 32;
        private IPlayer player;
        private Direction direction;
        public CloseableDoor(Vector2 pos, Direction direction)
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
                    closedSprite = spriteFactory.CreateNorthClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite northFrame = spriteFactory.CreateNorthOpenDoorTopFrameSprite();
                    northFrame.UpdatePos(pos);
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, northFrame);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateEastClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite eastFrame = spriteFactory.CreateEastOpenDoorTopFrameSprite();
                    eastFrame.UpdatePos(pos + new Vector2(64, 0));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, eastFrame);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateSouthClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    IAnimatedSprite southFrame = spriteFactory.CreateSouthOpenDoorTopFrameSprite();
                    southFrame.UpdatePos(pos + new Vector2(0, 64));
                    LevelManager.CurrentLevelRoom.AddDoor(direction, this, southFrame);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWestClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    IAnimatedSprite westFrame = spriteFactory.CreateWestOpenDoorTopFrameSprite();
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
            if (Closed) return;

            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player && !GameState.Link.StateMachine.isKnockedBack)
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

        public void Open()
        {
            if (Closed)
            {
                openCollider.Active = true;
                openSprite.RegisterSprite();

                closedCollider.Active = false;
                closedSprite.UnregisterSprite();
                SoundFactory.PlaySound(SoundFactory.getInstance().DoorUnlock);

                Closed = false;
            }
        }

        public void Close()
        {
            if (!Closed)
            {
                closedCollider.Active = true;
                closedSprite.RegisterSprite();

                openCollider.Active = false;
                openSprite.UnregisterSprite();
                SoundFactory.PlaySound(SoundFactory.getInstance().DoorUnlock);

                Closed = true;
            }
        }
    }
}
