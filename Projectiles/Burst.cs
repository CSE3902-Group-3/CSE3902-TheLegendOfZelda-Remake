using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class Burst
    {
        private Timer timer;
        private IAnimatedSprite sprite;

        private const double delay = .25;

        public Burst(Vector2 pos)
        {
            sprite = SpriteFactory.getInstance().CreateBurstSprite();
            sprite.UpdatePos(pos);
            timer = new Timer(delay, Destroy);
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
        }
    }
}
