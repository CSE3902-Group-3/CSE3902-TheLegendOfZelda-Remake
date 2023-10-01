using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class FlashingEffect : IAnimatedSpriteDrawEffect, IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Flashing";
        public string Name { get { return name; } }

        private int flashCounter = 0;
        private Color effectColor = Color.White;

        AnimatedSprite sprite;
        public FlashingEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            returnInfo.color = effectColor;
            return returnInfo;
        }

        public void ExecuteEffect()
        {
            switch (flashCounter)
            {
                case 0:
                    effectColor = Color.Blue;
                    break;
                case 1:
                    effectColor = Color.Green;
                    break;
                case 2:
                    effectColor = Color.Red;
                    break;
                default:
                    effectColor = Color.White;
                    flashCounter = -1;
                    break;
            }
            flashCounter++;
        }
    }
}
