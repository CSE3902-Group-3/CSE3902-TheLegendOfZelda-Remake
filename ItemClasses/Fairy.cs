using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Fairy : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite fairy;
        private SpriteFactory spriteFactory;


        public Fairy(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            fairy = spriteFactory.CreateFairySprite();
            fairy.UpdatePos(pos);
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

