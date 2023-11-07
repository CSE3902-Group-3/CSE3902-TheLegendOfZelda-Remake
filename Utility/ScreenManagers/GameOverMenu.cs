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

		/* CONTINUE letters */
		private AnimatedSprite C;
		private AnimatedSprite O;
		private AnimatedSprite N;
        private AnimatedSprite T;
		private AnimatedSprite I;
		private AnimatedSprite U;
		private AnimatedSprite E;

		/* SAVE letters */
		private AnimatedSprite S;
		private AnimatedSprite A;
		private AnimatedSprite V;

        /* RETRY letters */
        private AnimatedSprite R;
		private AnimatedSprite Y;

		private LetterFactory letterFactory;
		private int cameraXPos;
		private int cameraYPos;
		private int letterWidth;
		private GraphicsDevice graphicsDevice;

		public GameOverMenu()
		{
			letterFactory = LetterFactory.getInstance();
			letterWidth = 7;
			cameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
			cameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
			graphicsDevice = Game1.getInstance().GraphicsDevice;

			C = letterFactory.GetLetterSprite('C');
            O = letterFactory.GetLetterSprite('O');
            N = letterFactory.GetLetterSprite('N');
            T = letterFactory.GetLetterSprite('T');
            I = letterFactory.GetLetterSprite('I');
            U = letterFactory.GetLetterSprite('U');
            E = letterFactory.GetLetterSprite('E');

            S = letterFactory.GetLetterSprite('S');
            A = letterFactory.GetLetterSprite('A');
            V = letterFactory.GetLetterSprite('V');

            R = letterFactory.GetLetterSprite('R');
            Y = letterFactory.GetLetterSprite('Y');

			Continue = new List<AnimatedSprite>()
			{
				C, O, N, T, I, N, U, E
			};

			Save = new List<AnimatedSprite>()
			{
				S, A, V, E
			};

			Retry = new List<AnimatedSprite>()
			{
				R, E, T, R, Y
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
            int startXPos = cameraXPos + graphicsDevice.Viewport.Width / 2;
            int startYPos = cameraYPos + graphicsDevice.Viewport.Height / 3;
            for (int i = 0; i < Save.Count; i++)
            {
                Save[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
            }
        }

		private void DrawRetryWord()
		{
            int startXPos = (cameraXPos + graphicsDevice.Viewport.Width) * 2 / 3;
            int startYPos = cameraYPos + graphicsDevice.Viewport.Height / 3;
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

