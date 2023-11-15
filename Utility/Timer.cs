
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class Timer : IUpdateable
    {
        private double startTime;
        private double length;
        Action callback;
        bool init = false;
        
        public Timer(double length, Action callback)
        {
            this.length = length;
            this.callback = callback;
            LevelManager.AddUpdateable(this, true);
        }

        public void Update(GameTime gameTime)
        {
            if (!init)
            {
                startTime = gameTime.TotalGameTime.TotalSeconds;
                init = true;
            }
            else if(gameTime.TotalGameTime.TotalSeconds >= startTime + length)
            {
                callback();
                Destroy();
            }
        }

        public void Destroy()
        {
            LevelManager.RemoveUpdateable(this, true);
        }
    }
}
