using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public interface IEnemy: IUpdateable
    {
        void Spawn();
        void UpdateHealth(int damagePoints);
        void Attack();
        void ChangePosition();
        void ChangeDirection();
        void Die();
    }
}
