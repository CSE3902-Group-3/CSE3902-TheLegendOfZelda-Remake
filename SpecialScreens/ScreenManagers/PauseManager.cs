using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class PauseManager : IDrawable
    {
        private Game1 game;
        private bool paused;
        private Texture2D overlay;
        private GraphicsDevice graphicsDevice;
        private Rectangle overlayTexture;
        private Color color;
        private LetterFactory letterFactory;
        private List<AnimatedSprite> text;
        private int letterWidth;
        private int CameraXPos;
        private int CameraYPos;
        private int StartXPos;
        private int StartYPos;
        private int ScreenWidth;
        private int ScreenHeight;

        public PauseManager()
        {
            game = Game1.getInstance();
            paused = false;
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            color = new Color(120, 120, 120, 200);
            letterWidth = 30;
            letterFactory = LetterFactory.GetInstance();
            ScreenWidth = 1024;
            ScreenHeight = 896;
            text = new List<AnimatedSprite>()
            {
                letterFactory.GetLetterSprite('P'),
                letterFactory.GetLetterSprite('A'),
                letterFactory.GetLetterSprite('U'),
                letterFactory.GetLetterSprite('S'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetLetterSprite('D')
            };
        }

        public void TogglePause()
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        public void Pause()
        {
            paused = true;
            GameState.GetInstance().SwitchState(new PauseState());
            LevelManager.AddDrawable(this);
        }

        public void Resume()
        {
            paused = false;
            LevelManager.RemoveDrawable(this);
            GameState.GetInstance().SwitchState(new NormalState());
            for (int i = 0; i < text.Count; i++)
            {
                text[i].UnregisterSprite();
            }
        }

        public bool isPaused()
        {
            return paused;
        }

        public void Draw()
        {
            CameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
            StartXPos = CameraXPos + (ScreenWidth * 2 / 5) + 12;
            StartYPos = CameraYPos + (ScreenHeight * 3 / 5);

            overlay = SpriteFactory.getInstance().linkTexture;
            game._spriteBatch.Draw(overlay, new Rectangle(CameraXPos, CameraYPos, ScreenWidth, ScreenHeight), overlayTexture, color);
            for (int i = 0; i < text.Count; i++)
            {
                text[i].RegisterSprite();
                text[i].UpdatePos(new Vector2((StartXPos + letterWidth * i), StartYPos));
            }
        }

    }
}
