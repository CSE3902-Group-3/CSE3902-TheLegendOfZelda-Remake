using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    

    public class RectCollider : IRectCollider
    {
        public Rectangle Rect { get; set; }
        public CollisionLayer Layer { get; }
        public ICollidable Collidable { get; }
        public Vector2 Pos
        {
            get
            {
                return new Vector2(Rect.Left, Rect.Top);
            }
            set
            {
                Rect = new Rectangle((int) value.X, (int) value.Y, Rect.Width, Rect.Height);
            }
        }

        private bool _active;
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                if(_active == false && value == true)
                {
                    collisionManager.AddRectCollider(this);
                } else if(_active == true && value == false)
                {
                    collisionManager.RemoveRectCollider(this);
                }
                _active = value;
            }
        }

        private CollisionManager collisionManager;

        public RectCollider(Rectangle rect, CollisionLayer layer, ICollidable collidable)
        {
            this.Rect = rect;
            this.Layer = layer;
            this.Collidable = collidable;

            collisionManager = CollisionManager.instance;
            _active = true;
            collisionManager.AddRectCollider(this);
        }
    }
}
