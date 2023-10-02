using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LegendOfZelda
{
    public class StabLeftAdjustmentEffect : IAnimatedSpriteDrawEffect
    {
        public static readonly string name = "StabLeft";
        public string Name { get { return name; } }

        public DrawInfo ApplyEffect(DrawInfo drawInfo)
        {
            DrawInfo returnInfo = drawInfo;
            Vector2 oldPos = drawInfo.pos;
            returnInfo.pos = new Vector2(oldPos.X + (16 - drawInfo.frames[drawInfo.frame].Width) * drawInfo.scale, oldPos.Y);
            return returnInfo;
        }
    }
}
