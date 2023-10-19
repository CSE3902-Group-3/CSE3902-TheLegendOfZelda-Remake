
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.DataAnnotations;

namespace LegendOfZelda
{
    public class Timer : IUpdateable
    {
        private double startTime;
        private double length;
        Action callback;
        Game1 game1;
        bool init = false;
        
        public Timer(double length, Action callback)
        {
            this.length = length;
            this.callback = callback;
            game1 = Game1.getInstance();
            LevelMaster.RegisterUpdateable(this);
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
            LevelMaster.RemoveUpdateable(this);
        }
    }
}
