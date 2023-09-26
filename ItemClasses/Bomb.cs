using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bomb : IItem
    {
        protected AnimatedSprite bomb;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Bomb(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            bomb = spriteFactory.CreateBombSprite();
            position = pos;
        }

        public void Show()
        {
            bomb.RegisterSprite();
            bomb.UpdatePos(position);
        }

        public void Remove()
        {
            bomb.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

