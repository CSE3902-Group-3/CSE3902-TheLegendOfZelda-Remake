using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class StabLeftSprite : AnimatedSprite
    {

        public StabLeftSprite(Texture2D texture, Rectangle[] frames, SpriteEffects effect, int drawFramesPerAnimFrame, int scale) : base(texture, frames, effect, drawFramesPerAnimFrame, scale)
        {

        }

        protected override void DrawSprite()
        {
            Vector2 adjustedPos = new Vector2(pos.X + (16 - frames[frame].Width) * scale, pos.Y);
            spriteBatch.Draw(texture, adjustedPos, frames[frame], color, 0, Vector2.Zero, scale, effect, 1);
        }

    }
}