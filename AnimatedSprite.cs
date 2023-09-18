using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    public class AnimatedSprite : ISprite
    {
        protected Texture2D texture;
        protected Rectangle[] frames;
        protected int frame;
        protected SpriteBatch spriteBatch;
        protected int drawFramesPerAnimFrame;
        protected int currentFrameCounter = 0;
        protected int scale;
        protected Game1 game1;
        protected Vector2 pos = Vector2.Zero;
        protected SpriteEffects effect;
        public bool paused { get; set; }
        public Color color { get; set; } = Color.White;

        public AnimatedSprite(Texture2D texture, Rectangle[] frames, SpriteEffects effect, int drawFramesPerAnimFrame, int scale)
        {
            this.texture = texture;
            this.frames = frames;
            frame = 0;
            this.drawFramesPerAnimFrame = drawFramesPerAnimFrame;
            this.scale = scale;
            this.effect = effect;

            game1 = Game1.instance;
            spriteBatch = game1._spriteBatch;

            RegisterSprite();
        }

        //Overridden in sprite classes with special positioning
        public virtual void Draw()
        {
            spriteBatch.Draw(texture, pos, frames[frame], color, 0, Vector2.Zero, scale, effect, 1);

            if(!paused) UpdateFrame();
        }

        //This is overridden in sprite classes for special animations
        protected virtual void UpdateFrame()
        {
            currentFrameCounter++;
            if (currentFrameCounter >= drawFramesPerAnimFrame)
            {
                frame++;
                if (frame >= frames.Length)
                {
                    frame = 0;
                }
                currentFrameCounter = 0;
            }
        }

        //Left virtual in case this needs to be overridden in the future
        public virtual void UpdatePos(Vector2 pos)
        {
            this.pos = pos;
        }

        public void RegisterSprite()
        {
            game1.RegisterDrawable(this);
        }

        public void UnregisterSprite()
        {
            game1.RemoveDrawable(this);
        }
    }  
}
