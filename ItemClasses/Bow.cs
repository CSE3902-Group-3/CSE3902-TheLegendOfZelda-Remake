using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bow : IItem
    {
        protected AnimatedSprite bow;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Bow(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            bow = spriteFactory.CreateBowSprite();
            position = pos;
        }

        public void Show()
        {
            bow.RegisterSprite();
            bow.UpdatePos(position);
        }

        public void Remove()
        {
            bow.UnregisterSprite();
        }

        public AnimatedSprite Collect()
        {
            bow.UnregisterSprite();
            return bow;
        }
    }
}

