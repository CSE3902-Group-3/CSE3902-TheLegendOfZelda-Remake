using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class BoomerangAnimateEffect : IAnimatedSpriteUpdateEffect, IAnimatedSpriteDrawEffect
    {
        public static readonly string name = "Boomerang";
        public string Name { get { return name; } }

        private int nextCorner = 1;
        private Vector2 center;
        private AnimatedSprite sprite;

        public BoomerangAnimateEffect(AnimatedSprite sprite) 
        {
            this.sprite = sprite;
            center = new Vector2(sprite.drawInfo.frames[0].Width / 2, sprite.drawInfo.frames[0].Height / 2);
        }

        public void ExecuteEffect()
        {
            if (sprite.paused) return;
            sprite.drawInfo.frame++;
            if(sprite.drawInfo.frame >= sprite.drawInfo.frames.Length)
            {
                sprite.drawInfo.frame = 0;
                nextCorner = (nextCorner + 1) % 4;
            }
        }

        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            returnInfo.pos = sprite.pos + center * sprite.scale;
            returnInfo.rotation = -nextCorner * ((float)Math.PI / 2);
            returnInfo.origin = center;
            return returnInfo;
        }
    }
}
