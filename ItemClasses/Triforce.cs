using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Triforce : IItem, ICollidable
    {
        protected AnimatedSprite triforce;
        private Vector2 position;
        private RectCollider collider;
        private int scale = SpriteFactory.getInstance().scale;

        public Triforce(Vector2 pos)
        {
            triforce = SpriteFactory.getInstance().CreateTriforcePieceSprite();
            position = pos;
            collider = new RectCollider(new Rectangle((int)position.X, (int)position.Y, 12 * scale, 16 * scale), CollisionLayer.Item, this);
            collider.Pos = pos;
        }

        public void Show()
        {
            LevelManager.AddDrawable(triforce);
            triforce.UpdatePos(position);
        }

        public void Remove()
        {
            LevelManager.RemoveDrawable(triforce);
        }

        public IItem Collect()
        {
            LevelManager.RemoveDrawable(triforce);
            collider.Active = false;
            GameState.GetInstance().SwitchState(new WinningState());
            return this;
        }

        public void Use(Vector2 newPos)
        {
            triforce.RegisterSprite();
            triforce.UpdatePos(newPos);
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