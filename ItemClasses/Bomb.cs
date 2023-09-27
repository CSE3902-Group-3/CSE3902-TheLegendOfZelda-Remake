using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Bomb : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author

        protected AnimatedSprite bomb;
        private SpriteFactory spriteFactory;


        public Bomb(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            bomb = spriteFactory.CreateBombSprite();
            bomb.UpdatePos(pos);
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

