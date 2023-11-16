using System.Collections.Generic;
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
        private int StartXPos;
        private int StartYPos;
        private int letterWidth;
        private LetterFactory letterFactory;
        private AnimatedSprite G;
        private AnimatedSprite A;
        private AnimatedSprite M;
        private AnimatedSprite E;
        private AnimatedSprite space;
        private AnimatedSprite O;
        private AnimatedSprite V;
        private AnimatedSprite E2;
        private AnimatedSprite R;

        private List<AnimatedSprite> text;

        public GameOverText()
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            spriteBatch = game._spriteBatch;
            CameraXPos = (int)GameState.CameraController.gameOverCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.gameOverCamera.worldPos.Y;
            StartXPos = CameraXPos + (graphicsDevice.Viewport.Width * 2 / 5);
            StartYPos = CameraYPos + (graphicsDevice.Viewport.Height / 2);
            letterWidth = 30;
            letterFactory = LetterFactory.GetInstance();
            G = letterFactory.GetLetterSprite('G');
            A = letterFactory.GetLetterSprite('A');
            M = letterFactory.GetLetterSprite('M');
            E = letterFactory.GetLetterSprite('E');
            space = letterFactory.GetBlankSprite();
            O = letterFactory.GetLetterSprite('O');
            V = letterFactory.GetLetterSprite('V');
            E2 = letterFactory.GetLetterSprite('E');
            R = letterFactory.GetLetterSprite('R');

            text = new List<AnimatedSprite>()
            {
                G, A, M, E, space, O, V, E2, R
            };
        }

        public void Draw()
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].RegisterSprite();
                text[i].UpdatePos(new Vector2((StartXPos + letterWidth * i), StartYPos));
            }
        }

        public void Remove()
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].UnregisterSprite();
            }
        }
    }
}

