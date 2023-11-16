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
        private AnimatedSprite P;
        private AnimatedSprite A;
        private AnimatedSprite U;
        private AnimatedSprite S;
        private AnimatedSprite E;
        private AnimatedSprite D;
        private List<AnimatedSprite> text;
        private int letterWidth;
        private int CameraXPos;
        private int CameraYPos;
        private int StartXPos;
        private int StartYPos;

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
            P = letterFactory.GetLetterSprite('P');
            A = letterFactory.GetLetterSprite('A');
            U = letterFactory.GetLetterSprite('U');
            S = letterFactory.GetLetterSprite('S');
            E = letterFactory.GetLetterSprite('E');
            D = letterFactory.GetLetterSprite('D');
            text = new List<AnimatedSprite>()
            {
                P, A, U, S, E, D
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
            LevelMaster.RegisterDrawable(this);
        }

        public void Resume()
        {
            paused = false;
            LevelMaster.RemoveDrawable(this);
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
            StartXPos = CameraXPos + (graphicsDevice.Viewport.Width * 2 / 5);
            StartYPos = CameraYPos + (graphicsDevice.Viewport.Height / 2);

            overlay = SpriteFactory.getInstance().linkTexture;
            game._spriteBatch.Draw(overlay, new Rectangle(CameraXPos,CameraYPos,graphicsDevice.Viewport.Height, graphicsDevice.Viewport.Width), overlayTexture, color);
            for (int i = 0; i < text.Count; i++)
            {
                text[i].RegisterSprite();
                text[i].UpdatePos(new Vector2((StartXPos + letterWidth * i), StartYPos));
            }
        }

    }
}
