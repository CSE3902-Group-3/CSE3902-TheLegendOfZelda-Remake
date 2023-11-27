using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class ShaderFlashingEffect : IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Flashing";
        public string Name { get { return name; } }

        private int flashCounter = 0;

        AnimatedSprite sprite;
        public ShaderFlashingEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }

        public void ExecuteEffect()
        {
            switch (flashCounter)
            {
                case 0:
                    sprite.ActiveShader = ShaderHolder.flash1;
                    break;
                case 1:
                    sprite.ActiveShader = ShaderHolder.flash2;
                    break;
                case 2:
                    sprite.ActiveShader = ShaderHolder.blink;
                    break;
                default:
                    sprite.ActiveShader = ShaderHolder.normalShader;
                    flashCounter = -1;
                    break;
            }
            flashCounter++;
        }
    }
}
