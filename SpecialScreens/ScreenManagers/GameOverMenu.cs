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
		private AnimatedSprite N2;
		private AnimatedSprite U;
		private AnimatedSprite E;

		/* SAVE letters */
		private AnimatedSprite S;
		private AnimatedSprite A;
		private AnimatedSprite V;
		private AnimatedSprite E2;

        /* RETRY letters */
        private AnimatedSprite R;
		private AnimatedSprite E3;
		private AnimatedSprite T2;
		private AnimatedSprite R2;
		private AnimatedSprite Y;

		private LetterFactory letterFactory;
		private int cameraXPos;
		private int cameraYPos;
		private int letterWidth;
		private GraphicsDevice graphicsDevice;

		public GameOverMenu()
		{
			letterFactory = LetterFactory.getInstance();
			letterWidth = 30;
			cameraXPos = (int)GameState.CameraController.gameOverCamera.worldPos.X;
			cameraYPos = (int)GameState.CameraController.gameOverCamera.worldPos.Y;
			graphicsDevice = Game1.getInstance().GraphicsDevice;

			C = letterFactory.GetLetterSprite('C');
            O = letterFactory.GetLetterSprite('O');
            N = letterFactory.GetLetterSprite('N');
            T = letterFactory.GetLetterSprite('T');
            I = letterFactory.GetLetterSprite('I');
			N2 = letterFactory.GetLetterSprite('N');
            U = letterFactory.GetLetterSprite('U');
            E = letterFactory.GetLetterSprite('E');

            S = letterFactory.GetLetterSprite('S');
            A = letterFactory.GetLetterSprite('A');
            V = letterFactory.GetLetterSprite('V');
			E2 = letterFactory.GetLetterSprite('E');

            R = letterFactory.GetLetterSprite('R');
			E3 = letterFactory.GetLetterSprite('E');
			T2 = letterFactory.GetLetterSprite('T');
			R2 = letterFactory.GetLetterSprite('R');
            Y = letterFactory.GetLetterSprite('Y');

			Continue = new List<AnimatedSprite>()
			{
				C, O, N, T, I, N2, U, E
			};

			Save = new List<AnimatedSprite>()
			{
				S, A, V, E2
			};

			Retry = new List<AnimatedSprite>()
			{
				R, E3, T2, R2, Y
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

