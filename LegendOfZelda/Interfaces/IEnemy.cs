using System.Collections.Generic;

namespace LegendOfZelda.Interfaces
{
    public interface IEnemy
    {
        void ChangeDirection();
        void Update();
        void Draw();
    }
}
