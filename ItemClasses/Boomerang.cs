using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Boomerang : IItem
    {
        protected AnimatedSprite boomerang;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Boomerang(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            boomerang = spriteFactory.CreateBoomerangItemSprite();
            position = pos;
        }

        public void Show()
        {
            boomerang.RegisterSprite();
            boomerang.UpdatePos(position);
        }

        public void Remove()
        {
            boomerang.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

