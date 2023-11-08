﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
	public class LinkSpinningOverlay : IDrawable
	{
        private Texture2D overlay;
        private Game1 game;
        private Rectangle overlayTexture;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        private int CameraXPos;
        private int CameraYPos;
        private Color color;

        public LinkSpinningOverlay()
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            spriteBatch = game.SpriteBatch;
            CameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
            color = new Color(200, 0, 0, 50);
        }

        public void Draw()
        {
            spriteBatch.Draw(overlay, new Rectangle(CameraXPos, CameraYPos, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height), overlayTexture, color);
        }
    }
}

