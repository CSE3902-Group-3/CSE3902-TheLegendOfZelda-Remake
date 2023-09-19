using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Map : IItem
    {
        protected Texture2D texture;
        protected SpriteBatch spriteBatch;
        protected Game1 game1;
        public Vector2 position { get; protected set; }

        public Map(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            game1 = Game1.instance;
            spriteBatch = game1._spriteBatch;
        }

        public void Draw()
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

