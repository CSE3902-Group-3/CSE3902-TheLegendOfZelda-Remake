using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Arrow : IItem, ICollidable
    {
        protected AnimatedSprite arrow;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Arrow(Vector2 pos)
        {
            arrow = SpriteFactory.getInstance().CreateArrowUpSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            arrow.RegisterSprite();
            arrow.UpdatePos(position);
        }

        public void Remove()
        {
            arrow.UnregisterSprite();
        }

        public IItem Collect()
        {
            arrow.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            arrow.RegisterSprite();
            arrow.UpdatePos(newPos);
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

