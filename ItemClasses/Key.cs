using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Key : IItem
    {
        protected AnimatedSprite key;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Key(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            key = spriteFactory.CreateKeySprite();
            position = pos;
        }

        public void Show()
        {
            key.RegisterSprite();
            key.UpdatePos(position);
        }

        public void Remove()
        {
            key.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

