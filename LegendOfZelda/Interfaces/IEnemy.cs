using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Interfaces
{
    public interface IEnemy
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void UpdateHealth();
        void Attack();
    }
}
