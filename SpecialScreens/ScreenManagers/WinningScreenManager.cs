using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class WinningScreenManager : IUpdateable
	{
        private GraphicsDevice graphicsDevice;
        private WhiteFlash whiteFlash;
        private BlackCurtain curtain;
        private int curtainUpdateAmt;
        private int flashAmt;
        private double lastUpdate;
        private bool flashingWhite;
        private int flashingClosingFrequency;
        private int totalFlash;
        private int curtainAmt;
        private bool doneDrawing;
        private bool switchCamera;
        private int CameraXPos;
        private int CameraYPos;
        private int StartXPos;
        private int StartYPos;
        private int letterWidth;
        private LetterFactory letterFactory;
        private List<AnimatedSprite> text;
        private AnimatedSprite Triforce;
        
        public WinningScreenManager()
		{
            graphicsDevice = Game1.getInstance().GraphicsDevice;
            curtainUpdateAmt = 0;
            flashAmt = 0;
            whiteFlash = new WhiteFlash();
            lastUpdate = 0;
            flashingWhite = false;
            flashingClosingFrequency = 100;
            totalFlash = 6;
            curtainAmt = 16;
            doneDrawing = false;
            switchCamera = false;
            CameraXPos = (int)GameState.CameraController.mainCamera.worldPos.X;
            CameraYPos = (int)GameState.CameraController.mainCamera.worldPos.Y;
            StartXPos = CameraXPos + (graphicsDevice.Viewport.Width * 2 / 5);
            StartYPos = CameraYPos + (graphicsDevice.Viewport.Height / 3);
            letterWidth = 30;
            letterFactory = LetterFactory.GetInstance();
            Triforce = SpriteFactory.getInstance().CreateTriforcePieceSprite();
            LevelManager.AddDrawable(Triforce, true);
            Triforce.UpdatePos(GameState.Link.Pos + new Vector2(5, -50));

            text = new List<AnimatedSprite>()
            {
                letterFactory.GetLetterSprite('Y'),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('U'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('W'),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('N')
            };
        }

        private void DrawWhiteFlash()
        {
            if (!flashingWhite)
            {
                LevelManager.AddDrawable(whiteFlash);
                flashingWhite = true;
            }
            else if (flashingWhite)
            {
                LevelManager.RemoveDrawable(whiteFlash);
                flashingWhite = false;
                flashAmt++;
            }
        }

        private void DrawBlackCurtain()
        {
            curtain = new BlackCurtain(curtainUpdateAmt);
            LevelManager.AddDrawable(curtain);
        }

        private void ActivateWinningScreen()
        {
            LevelManager.AddUpdateable(this);
        }

        private void DrawWinningText()
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].RegisterSprite();
                text[i].UpdatePos(new Vector2((StartXPos + letterWidth * i), StartYPos));
            }
        }

        private void RemoveWinningText()
        {
            for (int i = 0; i < text.Count; i++)
            {
                text[i].UnregisterSprite();
            }
        }

        public void Update(GameTime gameTime)
        {
            if ((flashAmt < totalFlash) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + flashingClosingFrequency))
            {
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                DrawWhiteFlash();
            }

            /* This block is to ensure there are some time before curtain starts to close after flashing ends. */
            else if ((flashAmt == totalFlash) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
            { 
                DrawBlackCurtain();
                curtainUpdateAmt++;
                flashAmt++; // This is to make sure this block won't run again, not indicating actual flash
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }

            /* Screen will be all black after 16 updates */
            else if ((curtainUpdateAmt > 0) && (curtainUpdateAmt < curtainAmt) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + flashingClosingFrequency))
            {
                DrawBlackCurtain();
                curtainUpdateAmt++;
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                doneDrawing = true;
            }

            else if (doneDrawing && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 3000))
            {
                DrawWinningText();
                doneDrawing = false;
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                switchCamera = true;
            }

            else if (switchCamera && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 3000))
            {
                bool removed = LevelManager.RemoveDrawable(Triforce, true);
                GameState.CameraController.ChangeMenu(Menu.End);
                RemoveWinningText();
                GameState.Link.Sprite.UnregisterSprite();
                switchCamera = false;
            }
        }
	}
}

