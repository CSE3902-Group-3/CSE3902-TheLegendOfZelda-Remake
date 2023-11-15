using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IItem
    {
        void Show();
        void Remove();
        IItem Collect();
        void Use(Vector2 newPos);
    }
}