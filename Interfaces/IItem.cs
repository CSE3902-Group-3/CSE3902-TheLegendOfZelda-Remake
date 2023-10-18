using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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