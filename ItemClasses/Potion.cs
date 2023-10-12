using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Potion : IItem
    { 
        protected AnimatedSprite potion;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Potion(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            potion = spriteFactory.CreateBluePotionSprite();
            position = pos;
        }

        public void Show()
        {
            potion.RegisterSprite();
            potion.UpdatePos(position);
        }

        public void Remove()
        {
            potion.UnregisterSprite();
        }

        public IItem Collect()
        {
            potion.UnregisterSprite();
            return this;
        }
    }
}

