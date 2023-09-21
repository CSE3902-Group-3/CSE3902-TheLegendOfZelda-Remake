using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Interfaces
{
    public interface IPlayerProjectile
    {
        public enum Direction { left, right, up, down };
        public void Create(Vector2 position, Direction direction);
    }
}
