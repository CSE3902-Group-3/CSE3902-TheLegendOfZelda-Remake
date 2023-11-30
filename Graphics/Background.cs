using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LegendOfZelda.Graphics
{
    public class Background : ISprite, IHasShader
    {
        private const int blackPixelX = 64;
        private const int blackPixelY = 225;
        private const int backgroundWidth = 1024;
        private const int backgroundHeight = 1344;

        private SpriteBatch spriteBatch;
        private Texture2D linkTexture;
        private Rectangle dest;
        private Rectangle src;
        
        public Vector2 pos { get; private set; }

        public Effect ActiveShader => ShaderHolder.normalShader;

        public Background(int xPos, int yPos)
        {
            linkTexture = SpriteFactory.getInstance().linkTexture;
            spriteBatch = Game1.getInstance()._spriteBatch;
            dest = new Rectangle(xPos, yPos, backgroundWidth, backgroundHeight);
            src = new Rectangle(blackPixelX, blackPixelY, 1, 1);
            pos = new Vector2(xPos, yPos);

            RegisterSprite();
        }

        public void Draw()
        {
            spriteBatch.Draw(linkTexture, dest, src, Color.White);
        }

        public void RegisterSprite()
        {
            LevelManager.AddDrawable(this, true);
        }

        public void UnregisterSprite()
        {
            LevelManager.RemoveDrawable(this, true);
        }

        public void UpdatePos(Vector2 pos)
        {
            this.pos = pos;
            dest = new Rectangle((int)pos.X, (int)pos.Y, backgroundWidth, backgroundHeight);
        }
    }
}
