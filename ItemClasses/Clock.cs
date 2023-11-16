using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Clock : IItem, ICollidable
    {
        protected AnimatedSprite clock;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Clock(Vector2 pos)
        {
            clock = SpriteFactory.getInstance().CreateClockSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 12 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            clock.RegisterSprite();
            clock.UpdatePos(position);
        }

        public void Remove()
        {
            clock.UnregisterSprite();
        }

        public IItem Collect()
        {
            clock.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            clock.RegisterSprite();
            clock.UpdatePos(newPos);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.Player)
                {
                    Collect();
                }
            }
        }
    }
}

