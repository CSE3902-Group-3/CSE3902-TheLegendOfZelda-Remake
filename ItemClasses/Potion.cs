using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Potion : IItem, ICollidable
    { 
        protected AnimatedSprite potion;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Potion(Vector2 pos)
        {
            potion = SpriteFactory.getInstance().CreateBluePotionSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 8 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            potion.RegisterSprite();
            potion.UpdatePos(position);
        }

        public void Remove()
        {
            potion.UnregisterSprite();
        }

        public IItem Collect()
        {
            potion.UnregisterSprite();
            collider.Active = false;
            return this;
        }

        public void Use(Vector2 newPos)
        {
            potion.RegisterSprite();
            potion.UpdatePos(newPos);
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

