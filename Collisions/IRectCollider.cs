using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IRectCollider
    {
        public CollisionLayer Layer { get; }
        public Rectangle Rect { get; set; }
        public Vector2 Pos { get; set; }
        public bool Active { get; set; }

        public ICollidable Collidable { get; }
    }
}
