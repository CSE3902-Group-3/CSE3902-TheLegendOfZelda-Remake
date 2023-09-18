using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interfaces
{
    public interface IEnemyState
    {
        void ChangeDirection();
        void Update();
        void ChangePosition(SpriteBatch spritebatch, int x, int y);
    }
}
