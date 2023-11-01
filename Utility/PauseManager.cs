using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        public PauseManager()
        {
            game = Game1.getInstance();
            paused = false;
            graphicsDevice = game.GraphicsDevice;
            overlay = SpriteFactory.getInstance().linkTexture;
            overlayTexture = new Rectangle(118, 64, 1, 1);
            color = new Color(130, 130, 130, 180);
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
        }

        public bool isPaused()
        {
            return paused;
        }

        public void Draw()
        {
            overlay = SpriteFactory.getInstance().linkTexture;
            game._spriteBatch.Draw(overlay, new Rectangle(0,0,graphicsDevice.Viewport.Height, graphicsDevice.Viewport.Width), overlayTexture, color);
            game._spriteBatch.DrawString(SpriteFactory.getInstance().pauseWord, "PAUSED", new Vector2((graphicsDevice.Viewport.Height / 2) - 70, (graphicsDevice.Viewport.Width / 2) - 20), Color.Red);
            
        }

    }
}
