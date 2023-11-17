using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace LegendOfZelda
{
	public class GameOverMenu
	{
		private List<AnimatedSprite> Continue;
		private List<AnimatedSprite> Save;
		private List<AnimatedSprite> Retry;

		private LetterFactory letterFactory;
		private int cameraXPos;
		private int cameraYPos;
		private int letterWidth;
		private GraphicsDevice graphicsDevice;

		public GameOverMenu()
		{
			letterFactory = LetterFactory.GetInstance();
			letterWidth = 30;
			cameraXPos = (int)GameState.CameraController.GameOverLocation.X;
			cameraYPos = (int)GameState.CameraController.GameOverLocation.Y;
			graphicsDevice = Game1.getInstance().GraphicsDevice;

			Continue = new List<AnimatedSprite>()
			{
                letterFactory.GetLetterSprite('C'),
				letterFactory.GetLetterSprite('O'),
				letterFactory.GetLetterSprite('N'),
				letterFactory.GetLetterSprite('T'),
				letterFactory.GetLetterSprite('I'),
				letterFactory.GetLetterSprite('N'),
				letterFactory.GetLetterSprite('U'),
				letterFactory.GetLetterSprite('E')
			};

			Save = new List<AnimatedSprite>()
			{
                letterFactory.GetLetterSprite('S'),
				letterFactory.GetLetterSprite('A'),
				letterFactory.GetLetterSprite('V'),
				letterFactory.GetLetterSprite('E')
			};

			Retry = new List<AnimatedSprite>()
			{
                letterFactory.GetLetterSprite('R'),
				letterFactory.GetLetterSprite('E'),
				letterFactory.GetLetterSprite('T'),
				letterFactory.GetLetterSprite('R'),
				letterFactory.GetLetterSprite('Y')
			};
        }

		private void DrawContinueWord()
		{
			int startXPos = cameraXPos + graphicsDevice.Viewport.Width / 3;
			int startYPos = cameraYPos + graphicsDevice.Viewport.Height / 3;
			for (int i = 0; i < Continue.Count; i++)
			{
				Continue[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
			}
        }

		private void DrawSaveWord()
		{
            int startXPos = cameraXPos + graphicsDevice.Viewport.Width / 3;
            int startYPos = cameraYPos + graphicsDevice.Viewport.Height / 2;
            for (int i = 0; i < Save.Count; i++)
            {
                Save[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
            }
        }

		private void DrawRetryWord()
		{
            int startXPos = cameraXPos + graphicsDevice.Viewport.Width / 3;
            int startYPos = (cameraYPos + graphicsDevice.Viewport.Height) * 2 / 3;
            for (int i = 0; i < Retry.Count; i++)
            {
                Retry[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
            }
        }

		public void Draw()
		{
			DrawContinueWord();
			DrawSaveWord();
			DrawRetryWord();
		}
	}
}

