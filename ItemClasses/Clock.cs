using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Clock : IItem
    {
        protected AnimatedSprite clock;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Clock(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            clock = spriteFactory.CreateClockSprite();
            position = pos;
        }

        public void Show()
        {
            clock.RegisterSprite();
            clock.UpdatePos(position);
        }

        public void Remove()
        {
            clock.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

