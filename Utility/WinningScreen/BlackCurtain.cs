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
        private int cameraXPos;
        private int cameraYPos;

        public BlackCurtain(int updateAmt)
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            screenWidth = graphicsDevice.Viewport.Width;
            screenHeight = graphicsDevice.Viewport.Height;
            curtainWidth = screenWidth / 32; // The black curtain fully closes after 16 updates, so each piece should be 1/32 of screen width
            cameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
            cameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
            leftPos = cameraXPos + updateAmt * curtainWidth;
            rightPos = cameraXPos + screenWidth - (curtainWidth * (updateAmt + 1));
        }

        public void Draw()
        {
            game.SpriteBatch.Draw(overlay, new Rectangle(leftPos, cameraYPos, curtainWidth, screenHeight), overlayTexture, Color.Black);
            game.SpriteBatch.Draw(overlay, new Rectangle(rightPos, cameraYPos, curtainWidth,screenHeight), overlayTexture, Color.Black);
        }

	}
}

