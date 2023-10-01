using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MirrorAnimateEffect : IAnimatedSpriteUpdateEffect
    {
        public static readonly string name = "Mirror";
        public string Name { get { return name; } }

        AnimatedSprite sprite;
        public MirrorAnimateEffect(AnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public void ExecuteEffect()
        {
            if (sprite.paused) return;
            if (sprite.drawInfo.effect == SpriteEffects.FlipHorizontally)
            {
                sprite.drawInfo.effect = SpriteEffects.None;
            }
            else
            {
                sprite.drawInfo.effect = SpriteEffects.FlipHorizontally;
            }
        }
    }
}
