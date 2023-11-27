using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class ShaderBlinkEffect : IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Blink";
        public string Name { get { return name; } }

        private bool blinking = false;

        AnimatedSprite sprite;
        public ShaderBlinkEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }

        public void ExecuteEffect()
        {
            if (blinking)
            {
                sprite.ActiveShader = ShaderHolder.blink;
            }
            else
            {
                sprite.ActiveShader = sprite.StandardShader;
            }
        }
    }
}
