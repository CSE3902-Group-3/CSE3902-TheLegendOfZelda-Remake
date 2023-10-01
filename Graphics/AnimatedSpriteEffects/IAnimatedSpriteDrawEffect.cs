using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IAnimatedSpriteDrawEffect : IAnimatedSpriteEffect
    {
        public DrawInfo ApplyEffect(DrawInfo drawInfo);
    }
}
