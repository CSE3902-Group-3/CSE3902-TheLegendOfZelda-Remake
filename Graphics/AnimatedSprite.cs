using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    /*
     * Animated sprite implemented using the strategy pattern for animation effects
     */

    //This struct is used to lesson the amount of parameters that need to be passes around by animation effects
    public struct DrawInfo
    {
        public DrawInfo(Texture2D texture, Rectangle[] frames, float scale, SpriteEffects effect)
        {
            this.texture = texture;
            pos = Vector2.Zero;
            this.frames = frames;
            frame = 0;
            color = Color.White;
            rotation = 0;
            origin = Vector2.Zero;
            this.scale = scale;
            this.effect = effect;
        }

        public Texture2D texture;
        public Vector2 pos;
        public Rectangle[] frames;
        public int frame;
        public Color color;
        public float rotation;
        public Vector2 origin;
        public float scale;
        public SpriteEffects effect;
    }

    public class AnimatedSprite : IAnimatedSprite
    {
        

        //This is public so it can be freely modified by sprite effects
        public DrawInfo drawInfo;
        public int frame { get { return drawInfo.frame; } }

        protected SpriteBatch spriteBatch;
        protected int drawFramesPerAnimFrame;
        protected int currentFrameCounter = 0;
        public float scale { get { return drawInfo.scale; } }

        protected Game1 game1;
        public Vector2 pos { get { return drawInfo.pos; } }
        public bool paused { get; set; }
        public Color color { get { return drawInfo.color; } set { drawInfo.color = value; } }

        private int flashCounter = 0;
        private bool _flashing = false;
        public bool flashing
        {
            get { return _flashing; }
            set
            {
                if (value)
                {
                    AddEffect(new FlashingEffect(this));
                }
                else
                {
                    RemoveEffect(FlashingEffect.name);
                }
                _flashing = value;
            }
        }

        private bool _blinking = false;
        public bool blinking 
        {
            get { return _blinking; }
            set
            {
                if (value)
                {
                    AddEffect(new BlinkEffect(this));
                }
                else
                {
                    RemoveEffect(BlinkEffect.name);
                }
                _blinking = value;
            }
        }
        public bool complete { get; set; } = false;

        protected List<IAnimatedSpriteEffect> effectList;

        public AnimatedSprite(Texture2D texture, Rectangle[] frames, SpriteEffects effect, int drawFramesPerAnimFrame, int scale)
        {
            drawInfo = new DrawInfo(texture, frames, scale, effect);

            this.drawFramesPerAnimFrame = drawFramesPerAnimFrame;

            game1 = Game1.getInstance();
            spriteBatch = game1._spriteBatch;

            effectList = new List<IAnimatedSpriteEffect>();

            RegisterSprite();
        }

        public bool AddEffect(IAnimatedSpriteEffect effect)
        {
            foreach(IAnimatedSpriteEffect thisEffect in effectList)
            {
                if (thisEffect.Name.Equals(effect.Name))
                {
                    return false;
                }
            }

            effectList.Add(effect);
            return true;
        }

        public bool RemoveEffect(string effectName)
        {
            foreach (IAnimatedSpriteEffect thisEffect in effectList)
            {
                if (thisEffect.Name.Equals(effectName))
                {
                    effectList.Remove(thisEffect);
                    return true;
                }
            }

            return false;
        }
        
        public virtual void Draw()
        {
            DrawSprite();

            UpdateFrameCounter();        
        }

        protected virtual void DrawSprite()
        {
            DrawInfo tempDrawInfo = drawInfo;

            for(int i = effectList.Count - 1; i >= 0; i--)
            {
                if (effectList[i] is IAnimatedSpriteDrawEffect)
                {
                    IAnimatedSpriteDrawEffect drawEffect = (IAnimatedSpriteDrawEffect)(effectList[i]);
                    tempDrawInfo = drawEffect.ApplyEffect(tempDrawInfo);
                }
            }

            spriteBatch.Draw(tempDrawInfo.texture, tempDrawInfo.pos, tempDrawInfo.frames[drawInfo.frame], tempDrawInfo.color, tempDrawInfo.rotation, tempDrawInfo.origin, tempDrawInfo.scale, tempDrawInfo.effect, 1);
        }

        protected virtual void UpdateFrameCounter()
        {
            currentFrameCounter++;
            if (currentFrameCounter >= drawFramesPerAnimFrame)
            {
                for (int i = effectList.Count - 1; i >= 0; i--)
                {
                    if (effectList[i] is IAnimatedSpriteUpdateEffect)
                    {
                        IAnimatedSpriteUpdateEffect updateEffect = (IAnimatedSpriteUpdateEffect)(effectList[i]);
                        updateEffect.ExecuteEffect();
                    }
                }

                currentFrameCounter = 0;
            }
        }

        public virtual void UpdatePos(Vector2 pos)
        {
            drawInfo.pos = pos;
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
