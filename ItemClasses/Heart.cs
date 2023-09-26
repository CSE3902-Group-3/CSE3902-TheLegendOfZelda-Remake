using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Heart : IItem
    {
        protected AnimatedSprite heart;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Heart(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            heart = spriteFactory.CreateHeartSprite();
            position = pos;
        }

        public void Show()
        {
            heart.RegisterSprite();
            heart.UpdatePos(position);
        }

        public void Remove()
        {
            heart.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

