using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IEnemyProjectile : IUpdateable, ICollidable
    {
        void Destroy();
    }
}
