﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class MoveWestPushablBlock : ICollidable, IUpdateable
    {
        public bool Moved { get; private set; } = false;
        private ISprite sprite;
        private IRectCollider collider;
        private int wallSize = 16;
        private Vector2 _pos;
        private Timer timer;
        private const float pushDelay = (float)0.001;
        public BlockState state = BlockState.Idle;
        private Vector2 startingPos;

        private Vector2 targetPos;
        private const float moveSpeed = 1;
        private int CreatedInRoom;

        private Vector2 Pos
        {
            get { return _pos; }
            set {
                _pos = value;
                collider.Pos = value;
                sprite.UpdatePos(value);
            }
        }
            

        public MoveWestPushablBlock(Vector2 pos)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            sprite = spriteFactory.CreateWallSprite();
            sprite.UpdatePos(pos);
            wallSize *= spriteFactory.scale;
            startingPos = pos;
            _pos = pos;
            targetPos = pos + new Vector2(wallSize, 0);
            CreatedInRoom = LevelManager.CurrentRoom;

            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize), CollisionLayer.Wall, this);
            LevelManager.AddUpdateable(this, true);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach(CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer == CollisionLayer.Player)
                {
                    HandleCollisionWithPlayer(collision);
                    break;
                }
            }
        }

        private void HandleCollisionWithPlayer(CollisionInfo collision)
        {
            switch (state)
            {
                case BlockState.Idle:
                    if (collision.EstimatedDirection != Direction.left) break;
                    state = BlockState.Pushing;
                    timer = new Timer(pushDelay, StartMoving);
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (CreatedInRoom != LevelManager.CurrentRoom)
            {
                Reset();
                return;
            }
            switch (state)
            {
                case BlockState.Pushing:
                    if (!(GameState.Link.StateMachine.CurrentState is WalkRightLinkState))
                    {
                        state = BlockState.Idle;
                        timer.Destroy();
                    }
                    break;
                case BlockState.Moving:
                    Pos += new Vector2(moveSpeed, 0);
                    if(Pos.X >= targetPos.X)
                    {
                        Pos = targetPos;
                        state = BlockState.Pushed;
                    }
                    break;
            }
        }

        private void StartMoving()
        {
            if (state == BlockState.Pushing) state = BlockState.Moving;
            Moved = true;
        }

        public void Reset()
        {
            if (Moved)
            {
                Moved = false;
                Pos = startingPos;
                state = BlockState.Idle;
            }
        }
    }
}
