using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class NormalAnimateEffect : IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "NormalAnimate";
        public string Name { get { return name; } }

        AnimatedSprite sprite;
        public NormalAnimateEffect(AnimatedSprite sprite) 
        {
            this.sprite = sprite;
        }
        public void ExecuteEffect()
        {
            if (sprite.paused) return;
            sprite.drawInfo.frame++;
            if(sprite.drawInfo.frame >= sprite.drawInfo.frames.Length)
            {
                sprite.drawInfo.frame = 0;
            }
        }
    }
}
