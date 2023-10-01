using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //These animation effects have to have long(4) call chains to implement the strategy method, since they have to be separate classes
    public class AnimateOnlyOnceEffect : IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "AnimateOnlyOnce";
        public string Name { get { return name; } }

        AnimatedSprite sprite;
        public AnimateOnlyOnceEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public void ExecuteEffect()
        {
            if (sprite.paused) return;
            sprite.drawInfo.frame++;
            if (sprite.drawInfo.frame >= sprite.drawInfo.frames.Length)
            {
                sprite.drawInfo.frame--;
                sprite.complete = true;
                sprite.RemoveEffect(name);
            }
        }
    }
}
