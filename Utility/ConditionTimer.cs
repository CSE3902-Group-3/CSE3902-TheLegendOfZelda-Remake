using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    internal class ConditionTimer : IUpdateable
    {
        private double startTime;
        private double length;
        Action callback;
        Func<bool> condition;
        bool init = false;

        public ConditionTimer(double length, Action callback, Func<bool> condition)
        {
            this.length = length;
            this.callback = callback;
            LevelManager.AddUpdateable(this, false);
            this.condition = condition;
        }

        public void Update(GameTime gameTime)
        {
            if (!init)
            {
                startTime = gameTime.TotalGameTime.TotalSeconds;
                init = true;
            }
            else if (condition() && gameTime.TotalGameTime.TotalSeconds >= startTime + length)
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
