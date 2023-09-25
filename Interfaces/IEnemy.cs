using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Interfaces
{
    public interface IEnemy: IUpdateable
    {
        void UpdateHealth();
        void Attack();
        void ChangePosition();
        void ChangeDirection();
        void Destroy();
    }
}
