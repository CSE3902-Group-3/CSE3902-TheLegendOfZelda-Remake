using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Candle : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author

        protected AnimatedSprite candle;
        private SpriteFactory spriteFactory;


        public Candle(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            candle = spriteFactory.CreateBlueCandleSprite();
            candle.UpdatePos(pos);
        }

        public void Remove()
        {
            candle.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

