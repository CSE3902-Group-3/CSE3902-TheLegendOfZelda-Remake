using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Arrow : IItem
    {
        protected AnimatedSprite arrow;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Arrow(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            arrow = spriteFactory.CreateArrowUpSprite();
            position = pos;
        }

        public void Show()
        {
            arrow.RegisterSprite();
            arrow.UpdatePos(position);
        }

        public void Remove()
        {
            arrow.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }

        
    }
}

