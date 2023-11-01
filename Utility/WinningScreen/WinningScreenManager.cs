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
                LevelMaster.RegisterDrawable(whiteFlash);
                flashAmt++;
            }
            else if (flashingWhite)
            {
                LevelMaster.RemoveDrawable(whiteFlash);
            }
        }

        public void DrawBlackCurtain()
        {
            curtain = new BlackCurtain(curtainUpdateAmt);
            LevelMaster.RegisterDrawable(curtain);
        }

        public void ActivateWinningScreen()
        {
            LevelMaster.RegisterUpdateable(this);
        }


        public void Update(GameTime gameTime)
        {
            if ((flashAmt < 6) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                DrawWhiteFlash();
            }

            /* This block is to ensure there are some time before curtain starts to close after flashing ends. */
            if ((flashAmt == 6) && (curtainUpdateAmt == 0) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
            {
                DrawBlackCurtain();
                curtainUpdateAmt++;
            }

            /* Screen will be all black after 16 updates */
            if ((curtainUpdateAmt > 0) && (curtainUpdateAmt < 16) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
                DrawBlackCurtain();
                curtainUpdateAmt++;
            }
        }
	}
}

