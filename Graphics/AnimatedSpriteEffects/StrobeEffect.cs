using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class StrobeEffect : IAnimatedSpriteDrawEffect, IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Strobe";
        public string Name { get { return name; } }

        private bool strobe = false;

        AnimatedSprite sprite;
        public StrobeEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            if (strobe)
            {
                returnInfo.color = new Color(1, 1, 1, 0);
            }
            
            return returnInfo;
        }

        public void ExecuteEffect()
        {
            strobe = !strobe;
        }
    }
}
