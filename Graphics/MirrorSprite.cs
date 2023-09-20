﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MirrorSprite : AnimatedSprite
    {
        public MirrorSprite(Texture2D texture, Rectangle[] frames, SpriteEffects effect, int drawFramesPerAnimFrame, int scale) : base(texture, frames, effect, drawFramesPerAnimFrame, scale)
        {

        }

        protected override void UpdateFrame()
        {
            
            if(effect == SpriteEffects.FlipHorizontally)
            {
                effect = SpriteEffects.None;
            } else
            {
                effect = SpriteEffects.FlipHorizontally;
            }

        }
    }
}