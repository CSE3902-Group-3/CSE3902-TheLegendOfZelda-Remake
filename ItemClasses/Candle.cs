using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Candle : IItem
    {
        protected AnimatedSprite candle;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Candle(Vector2 pos)
        {
            spriteFactory = Game1.getInstance().spriteFactory;
            candle = spriteFactory.CreateBlueCandleSprite();
            position = pos;
        }

        public void Show()
        {
            candle.RegisterSprite();
            candle.UpdatePos(position);
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

