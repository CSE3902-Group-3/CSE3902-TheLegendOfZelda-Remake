using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface IAnimatedSprite : ISprite
    {
        public int frame { get; }
        public float scale { get; }
        public bool paused { get; set; }
        public Color color { get; set; }
        public bool flashing { get; set; }
        public bool blinking { get; set; }
        public bool complete { get; }

        public bool AddEffect(IAnimatedSpriteEffect effect);

        public bool RemoveEffect(string effectName);

    }
}
