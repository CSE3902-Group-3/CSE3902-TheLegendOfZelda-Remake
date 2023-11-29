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
            LevelManager.CurrentLevelRoom.AddDoor(direction, this);


            switch (direction)
            {
                case Direction.up:
                    openSprite = spriteFactory.CreateNorthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateNorthClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateEastClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateSouthClosedDoorSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestOpenDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWestClosedDoorSprite();
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
            if (Closed) return;

            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    player = GameState.Link;
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

                Closed = true;
            }
        }
    }
}
