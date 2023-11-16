using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
	public class GameOverText : IDrawable
	{
        private Game1 game;
        private GraphicsDevice graphicsDevice;
        private int CameraXPos;
        private int CameraYPos;
        private int StartXPos;
        private int StartYPos;
        private int letterWidth;
        private LetterFactory letterFactory;

        private List<AnimatedSprite> text;

        public GameOverText()
		{
            game = Game1.getInstance();
            graphicsDevice = game.GraphicsDevice;
            CameraXPos = (int)GameState.CameraController.gameOverCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.gameOverCamera.worldPos.Y;
            StartXPos = CameraXPos + (graphicsDevice.Viewport.Width * 2 / 5);
            StartYPos = CameraYPos + (graphicsDevice.Viewport.Height / 2);
            letterWidth = 30;
            letterFactory = LetterFactory.GetInstance();

            text = new List<AnimatedSprite>()
            {
                letterFactory.GetLetterSprite('G'),
                letterFactory.GetLetterSprite('A'),
                letterFactory.GetLetterSprite('M'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('V'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetLetterSprite('R')
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

