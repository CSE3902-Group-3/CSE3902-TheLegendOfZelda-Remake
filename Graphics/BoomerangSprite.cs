using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Graphics
{
    public class BoomerangSprite : AnimatedSprite
    {
        private int nextCorner = 1;
        private Vector2 center;
        public BoomerangSprite(Texture2D texture, Rectangle[] frames, SpriteEffects effect, int drawFramesPerAnimFrame, int scale, bool repeating) : base(texture, frames, effect, drawFramesPerAnimFrame, scale, repeating)
        {
            center = new Vector2(frames[0].Width/2, frames[0].Height/2);
        }

        protected override void DrawSprite()
        {
            spriteBatch.Draw(texture, pos + center * scale, frames[frame], color, -nextCorner * ((float)Math.PI/2), center, scale, effect, 1);
        }

        protected override void UpdateFrame()
        {
            base.UpdateFrame();
            if(frame == 0)
            {
                nextCorner = (nextCorner + 1) % 4;
            }
            
        }
    }
}