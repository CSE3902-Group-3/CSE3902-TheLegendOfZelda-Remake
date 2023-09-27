using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Key : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite key;
        private SpriteFactory spriteFactory;


        public Key(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            key = spriteFactory.CreateKeySprite();
            key.UpdatePos(pos);
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

