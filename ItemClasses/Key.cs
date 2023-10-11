using LegendOfZelda;
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
            spriteFactory = SpriteFactory.getInstance();
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

        public IItem Collect()
        {
            key.UnregisterSprite();
            return this;
        }
    }
}

