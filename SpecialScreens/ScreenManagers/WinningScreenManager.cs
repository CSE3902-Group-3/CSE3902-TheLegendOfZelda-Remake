using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace LegendOfZelda
{
	public class WinningScreenManager : IUpdateable
	{
        private WhiteFlash whiteFlash;
        private BlackCurtain curtain;
        private int curtainUpdateAmt;
        private int flashAmt;
        private double lastUpdate;
        private bool flashingWhite;
        
        public WinningScreenManager()
		{
            curtainUpdateAmt = 0;
            flashAmt = 0;
            whiteFlash = new WhiteFlash();
            lastUpdate = 0;
            flashingWhite = false;
        }

        public void DrawWhiteFlash()
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

        public void DrawBlackCurtain()
        {
            curtain = new BlackCurtain(curtainUpdateAmt);
            LevelManager.AddDrawable(curtain);
        }

        public void ActivateWinningScreen()
        {
            LevelManager.AddUpdateable(this);
        }


        public void Update(GameTime gameTime)
        {
            if ((flashAmt < 6) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                DrawWhiteFlash();
            }

            /* This block is to ensure there are some time before curtain starts to close after flashing ends. */
            if ((flashAmt == 6) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
            { 
                DrawBlackCurtain();
                curtainUpdateAmt++;
                flashAmt++; // This is to make sure this block won't run again, not indicating actual flash
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }

            /* Screen will be all black after 16 updates */
            if ((curtainUpdateAmt > 0) && (curtainUpdateAmt < 16) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
                DrawBlackCurtain();
                curtainUpdateAmt++;
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }
	}
}

