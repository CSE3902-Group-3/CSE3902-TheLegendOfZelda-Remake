using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
	public class GameOverText : IDrawable
	{
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;
        private int CameraXPos;
        private int CameraYPos;

        public GameOverText()
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            spriteBatch = game._spriteBatch;
            CameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
        }

        public void Draw()
        {
            spriteBatch.DrawString(SpriteFactory.getInstance().pauseWord, "GAME OVER", new Vector2(CameraXPos + (graphicsDevice.Viewport.Width / 2) - 70, CameraYPos + (graphicsDevice.Viewport.Height / 2) - 20), Color.White);
        }
    }
}

