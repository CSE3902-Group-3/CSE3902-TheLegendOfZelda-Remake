using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Compass : IItem
    {
        protected AnimatedSprite compass;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Compass(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            compass = spriteFactory.CreateCompassSprite();
            position = pos;
        }

        public void Show()
        {
            compass.RegisterSprite();
            compass.UpdatePos(position);
        }

        public void Remove()
        {
            compass.UnregisterSprite();
        }

        public AnimatedSprite Collect()
        {
            compass.UnregisterSprite();
            return compass;
        }
    }
}

