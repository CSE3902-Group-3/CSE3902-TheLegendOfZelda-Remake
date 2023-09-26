using LegendOfZelda;
using LegendOfZelda.Interfaces;
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
            spriteFactory = Game1.instance.spriteFactory;
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

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

