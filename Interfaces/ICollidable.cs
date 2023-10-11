using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ICollidable
    {
        public void OnCollision(List<CollisionInfo> collisions);
    }
}
