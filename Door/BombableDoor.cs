﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BombableDoor : ICollidable
    {
        private IAnimatedSprite openSprite;
        private IAnimatedSprite closedSprite;

        public bool Closed { get; private set; }

        private IRectCollider closedCollider;
        private IRectCollider openCollider;

        private int wallSize = 32;
        private IPlayer player;
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
                    break;
                case Direction.right:
                    openSprite = spriteFactory.CreateEastHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallEastSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X + wallSize / 2, (int)pos.Y, wallSize / 2, wallSize), CollisionLayer.OuterWall, this);
                    break;
                case Direction.down:
                    openSprite = spriteFactory.CreateSouthHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallSouthSprite();
                    closedSprite.UpdatePos(pos);
                    openCollider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + wallSize / 2, wallSize, wallSize / 2), CollisionLayer.OuterWall, this);
                    break;
                case Direction.left:
                    openSprite = spriteFactory.CreateWestHoleDoorSprite();
                    openSprite.UpdatePos(pos);
                    closedSprite = spriteFactory.CreateWallWestSprite();
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
            bool transitionEntered = false;
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
                OpenDoor();
            }
        }

        private void HandleCollisionWhenUnlocked(CollisionInfo collision)
        {
            if (collision.CollidedWith.Layer != CollisionLayer.Player) return;

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
