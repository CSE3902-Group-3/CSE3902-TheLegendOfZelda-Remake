using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Boomerang : IItem, ICollidable
    {
        protected AnimatedSprite boomerang;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Boomerang(Vector2 pos)
        {
            boomerang = SpriteFactory.getInstance().CreateBoomerangItemSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 8 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            boomerang.RegisterSprite();
            boomerang.UpdatePos(position);
        }

        public void Remove()
        {
            boomerang.UnregisterSprite();
        }

        public IItem Collect()
        {
            boomerang.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            boomerang.RegisterSprite();
            boomerang.UpdatePos(newPos);
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

