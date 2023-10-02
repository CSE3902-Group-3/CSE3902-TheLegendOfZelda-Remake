using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Boomerang : IItem
    {
        protected AnimatedSprite boomerang;
        private Vector2 position;

        public Boomerang(Vector2 pos)
        {
            boomerang = SpriteFactory.getInstance().CreateBoomerangItemSprite();
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

