using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class BlinkEffect : IAnimatedSpriteDrawEffect, IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Blink";
        public string Name { get { return name; } }

        private bool blinking = false;
        private Color effectColor = Color.Red;

        AnimatedSprite sprite;
        public BlinkEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            if(blinking) returnInfo.color = effectColor;
            return returnInfo;
        }

        public void ExecuteEffect()
        {
            if (blinking)
            {
                sprite.blinking = false;
            }
            else
            {
                blinking = true;
            }
        }
    }
}
