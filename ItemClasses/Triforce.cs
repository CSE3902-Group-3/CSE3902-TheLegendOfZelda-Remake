using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Triforce : IItem
    {
        protected AnimatedSprite triforce;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Triforce(Vector2 pos)
        {
            spriteFactory = SpriteFactory.getInstance();
            triforce = spriteFactory.CreateTriforcePieceSprite();
            position = pos;
        }

        public void Show()
        {
            triforce.RegisterSprite();
            triforce.UpdatePos(position);
        }

        public void Remove()
        {
            triforce.UnregisterSprite();
        }

        public AnimatedSprite Collect()
        {
            triforce.UnregisterSprite();
            return triforce;
        }
    }
}

