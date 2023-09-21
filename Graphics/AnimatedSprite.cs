using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AnimatedSprite : ISprite
    {
        protected Texture2D texture;
        protected Rectangle[] frames;
        public int frame { get; protected set; }
        protected SpriteBatch spriteBatch;
        protected int drawFramesPerAnimFrame;
        protected int currentFrameCounter = 0;
        protected int scale;
        protected Game1 game1;
        public Vector2 pos { get; protected set; } = Vector2.Zero;
        protected SpriteEffects effect;
        public bool paused { get; set; }
        public Color color { get; private set; } = Color.White;
        private int currentShader = 0;

        private int flashCounter = 0;
        private bool _flashing = false;
        public bool flashing { get; set; }

        public bool blinking { get; set; }

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

        //A bit of redundancy here to loosen coupling for extension
        public virtual void Draw()
        {
            DrawSprite();

            UpdateFrameCounter();        
        }

        //Overridden in sprites with special positioning
        protected virtual void DrawSprite()
        {
            spriteBatch.Draw(texture, pos, frames[frame], color, 0, Vector2.Zero, scale, effect, 1);
        }

        //The rest are left virtual in case it needs to be overridden in future
        protected virtual void UpdateFrameCounter()
        {
            currentFrameCounter++;
            if (currentFrameCounter >= drawFramesPerAnimFrame)
            {
                if (!paused) UpdateFrame();
                if (flashing) UpdateFlash();
                if (blinking) UpdateBlink();
                currentFrameCounter = 0;
            }
        }

        protected virtual void UpdateFlash()
        {
            switch (flashCounter)
            {
                case 0:
                    color = Color.Blue;
                    break;
                case 1:
                    color = Color.Green;
                    break;
                case 2:
                    color = Color.Red; 
                    break;
                default:
                    color = Color.White;
                    flashCounter = 0;
                    break;
            }
            flashCounter++;
        }

        protected virtual void UpdateBlink()
        {
            if(!color.Equals(Color.Red))
            {
                color = Color.Red;
            } else
            {
                color = Color.White;
                blinking = false;
            }
        }

        //This is overridden in sprite classes with special frame orders
        protected virtual void UpdateFrame()
        {
            frame++;
            if (frame >= frames.Length)
            {
                frame = 0;
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
