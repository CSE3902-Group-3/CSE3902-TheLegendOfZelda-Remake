using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public enum BlockState { Idle, Pushing, Moving, Pushed };
    public class MoveSouthPushableBlock : ICollidable, IUpdateable
    {
        public bool Moved { get; private set; } = false;
        private ISprite sprite;
        private IRectCollider collider;
        private int wallSize = 16;
        private Vector2 _pos;
        private Timer timer;
        private const float pushDelay = (float)0.001;
        public BlockState state { get; private set; } = BlockState.Idle;
        private Vector2 startingPos;

        private Vector2 targetPos;
        private Vector2 moveVec;
        private const float distThreshold = 2;
        private const float moveSpeed = 1;
        private Direction dirPushing = Direction.down;
        private int CreatedInRoom;

        private Vector2 Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                collider.Pos = value;
                sprite.UpdatePos(value);
            }
        }


        public MoveSouthPushableBlock(Vector2 pos)
        {
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            sprite = spriteFactory.CreateWallSprite();
            sprite.UpdatePos(pos);
            wallSize *= spriteFactory.scale;
            startingPos = pos;
            _pos = pos;

            collider = new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, wallSize, wallSize), CollisionLayer.Wall, this);
            CreatedInRoom = LevelManager.CurrentRoom;
            LevelManager.AddUpdateable(this, true);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if (collision.CollidedWith.Layer == CollisionLayer.Player)
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
                    dirPushing = OppositeDirection(collision.EstimatedDirection);
                    state = BlockState.Pushing;
                    timer = new Timer(pushDelay, StartMoving);
                    break;
            }
        }
        public static Direction OppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.down: return Direction.up;
                case Direction.up: return Direction.down;
                case Direction.left: return Direction.right;
                case Direction.right: return Direction.left;
            }
            return Direction.up;
        }

        public void Update(GameTime gameTime)
        {
            if (LevelManager.CurrentRoom != CreatedInRoom)
            {
                Reset();
                return;
            }
            switch (state)
            {
                case BlockState.Pushing:
                    if (IsLinkStillPushing())
                    {
                        state = BlockState.Idle;
                        timer.Destroy();
                    }
                    break;
                case BlockState.Moving:
                    Pos += moveVec;
                    if (Vector2.Distance(Pos, targetPos) < distThreshold)
                    {
                        Pos = targetPos;
                        state = BlockState.Pushed;
                    }
                    break;
            }
        }

        private bool IsLinkStillPushing()
        {
            IState linkBlockState = GameState.Link.StateMachine.CurrentState;

            switch (OppositeDirection(dirPushing))
            {
                case Direction.down:
                    return linkBlockState is WalkDownLinkState;
                case Direction.up:
                    return linkBlockState is WalkUpLinkState;
                case Direction.left:
                    return linkBlockState is WalkLeftLinkState;
                case Direction.right:
                    return linkBlockState is WalkRightLinkState;
            }
            return false;
        }
        private void StartMoving()
        {
            if (state == BlockState.Pushing)
            {
                Moved = true;
                state = BlockState.Moving;
                switch(dirPushing)
                {
                    case Direction.down:
                        moveVec = new Vector2(0, moveSpeed);
                        targetPos = Pos + new Vector2(0, wallSize);
                        break;
                    case Direction.up:
                        moveVec = new Vector2(0, -moveSpeed);
                        targetPos = Pos + new Vector2(0, -wallSize);
                        break;
                    case Direction.left:
                        moveVec = new Vector2(-moveSpeed, 0);
                        targetPos = Pos + new Vector2(-wallSize, 0);
                        break;
                    case Direction.right:
                        moveVec = new Vector2(moveSpeed, 0);
                        targetPos = Pos + new Vector2(wallSize, 0);
                        break;
                }
            }
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
