using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class WhiteFlash : IDrawable
	{
        private Texture2D overlay;
        private GraphicsDevice graphicsDevice;
        private Rectangle overlayTexture;
        private Game1 game;
        private int screenWidth;
        private int screenHeight;

        public WhiteFlash()
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            screenWidth = graphicsDevice.Viewport.Width;
            screenHeight = graphicsDevice.Viewport.Height;
        }

		public void Draw()
		{
            game.SpriteBatch.Draw(overlay, new Rectangle((int)GameState.CameraController.mainCamera.worldPos.X, (int)GameState.CameraController.mainCamera.worldPos.Y, screenWidth, screenHeight), overlayTexture, Color.White);
        }
	}
}

