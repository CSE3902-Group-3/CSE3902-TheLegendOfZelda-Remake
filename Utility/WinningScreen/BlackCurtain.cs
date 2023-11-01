using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LegendOfZelda
{
	public class BlackCurtain : IDrawable
	{
        private Texture2D overlay;
        private GraphicsDevice graphicsDevice;
        private Rectangle overlayTexture;
        private Game1 game;
        private int screenWidth;
        private int screenHeight;
        private int curtainWidth;
        private int leftPos;
        private int rightPos;

        public BlackCurtain(int updateAmt)
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            screenWidth = graphicsDevice.Viewport.Width;
            screenHeight = graphicsDevice.Viewport.Height;
            curtainWidth = screenWidth / 32; // The black curtain fully closes after 16 updates, so each piece should be 1/32 of screen width
            leftPos = updateAmt * curtainWidth;
            rightPos = screenWidth - leftPos - curtainWidth;
        }

        public void Draw()
        {
            game._spriteBatch.Draw(overlay, new Rectangle(leftPos, 0, screenHeight, curtainWidth), overlayTexture, Color.Black);
            game._spriteBatch.Draw(overlay, new Rectangle(rightPos, 0, screenHeight, curtainWidth), overlayTexture, Color.Black);
        }

	}
}

