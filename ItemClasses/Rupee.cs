using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Rupee : IItem
    {
        protected AnimatedSprite rupee;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Rupee(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            rupee = spriteFactory.CreateRupeeSprite();
            position = pos;
        }

        public void Show()
        {
            rupee.RegisterSprite();
            rupee.UpdatePos(position);
        }

        public void Remove()
        {
            rupee.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

