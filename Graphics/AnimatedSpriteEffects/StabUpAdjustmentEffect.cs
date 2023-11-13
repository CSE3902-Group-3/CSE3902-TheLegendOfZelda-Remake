using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class StabUpAdjustmentEffect : IAnimatedSpriteDrawEffect
    {
        public static readonly string name = "StabUp";
        public string Name { get { return name; } }

        private const int linkHeight = 16;

        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            Vector2 oldPos = drawInfo.pos;
            returnInfo.pos = new Vector2(oldPos.X, oldPos.Y + (linkHeight - drawInfo.frames[drawInfo.frame].Height) * drawInfo.scale);
            return returnInfo;
        }
    }
}
