using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Interfaces
{
    internal interface EnemyProjectile : IUpdateable
    {
        void Update();
        void Destroy();
    }
}
