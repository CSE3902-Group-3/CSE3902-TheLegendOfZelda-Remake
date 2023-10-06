//This class is not for the final game but for testing and demonstrating the collision system

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class CollisionDemoObject : ICollidable, IUpdateable
    {
        private IAnimatedSprite sprite;
        private IRectCollider collider;
        private Random random;
        private Vector2 speed;

        private Vector2 _position;
        private Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                sprite.UpdatePos(value);
                collider.Pos = value;
            }
        }


        public CollisionDemoObject(IAnimatedSprite sprite, CollisionLayer layer, int width, int height) {
            this.sprite = sprite;
            random = new Random();

            _position = new Vector2((float)random.NextDouble() * 1000, (float)random.NextDouble() * 800);
            speed = new Vector2((float)random.NextDouble() * 2 + 2, (float)random.NextDouble() * 2 - 2);
            sprite.UpdatePos(_position);

            int scale = SpriteFactory.getInstance().scale;
            collider = new RectCollider(
                new Rectangle((int)_position.X, (int)+_position.Y, width * scale, height * scale),
                layer,
                this
            );

            Game1.getInstance().RegisterUpdateable(this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                if(collision.CollidedWith.Layer == CollisionLayer.Wall)
                {
                    HandleCollisionWithWall(collision.EstimatedDirection, collision.OverlapRectangle);
                } else
                {
                    HandleCollisionWithEntity();
                }
            }
        }

        private void HandleCollisionWithWall(Direction direction, Rectangle overlapRectangle)
        {
            switch (direction)
            {
                case Direction.up:
                    speed = new Vector2(speed.X, (float)random.NextDouble() * 2.5f + 2);
                    Position = new Vector2(Position.X, Position.Y + overlapRectangle.Height);
                    break;
                case Direction.down:
                    speed = new Vector2(speed.X, -(float)random.NextDouble() * 2.5f - 2);
                    Position = new Vector2(Position.X, Position.Y - overlapRectangle.Height);
                    break;
                case Direction.right:
                    speed = new Vector2(-(float)random.NextDouble() * 2.5f - 2, speed.Y);
                    Position = new Vector2(Position.X - overlapRectangle.Width, Position.Y);
                    break;
                case Direction.left:
                    speed = new Vector2((float)random.NextDouble() * 2.5f + 2, speed.Y);
                    Position = new Vector2(Position.X + overlapRectangle.Width, Position.Y);
                    break;
            }
        }

        private void HandleCollisionWithEntity()
        {
            sprite.color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1);
        }

        public void Update(GameTime gameTime)
        {
            Position += speed;
        }
    }
}
