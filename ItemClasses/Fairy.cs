using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Fairy : IItem
    {
        protected AnimatedSprite fairy;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Fairy(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            fairy = spriteFactory.CreateFairySprite();
            position = pos;
        }

        public void Show()
        {
            fairy.RegisterSprite();
            fairy.UpdatePos(position);
        }

        public void Remove()
        {
            fairy.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

