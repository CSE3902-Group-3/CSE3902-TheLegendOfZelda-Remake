using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LegendOfZelda
{
	public class GameOverScreen : IUpdateable
	{
		private LinkSpinningOverlay linkSpinningOverlay;
		private LightRed lightRed;
		private NormalRed red;
		private DarkRed darkRed;
		private BlackScreen blackScreen;
		private GameOverText text;
		private double lastUpdate;
		private int counter;

		public GameOverScreen()
		{
			linkSpinningOverlay = new LinkSpinningOverlay();
			lightRed = new LightRed();
			red = new NormalRed();
			darkRed = new DarkRed();
			blackScreen = new BlackScreen();
			text = new GameOverText();
			lastUpdate = 0;
			counter = 0;
        }

		public void ActivateGameOver()
		{
			LevelMaster.RegisterUpdateable(this);
		}

		private void DrawLinkSpinningOverlay()
		{
			LevelMaster.RegisterDrawable(linkSpinningOverlay);
        }

		private void DrawLightRed()
		{
			LevelMaster.RegisterDrawable(lightRed);
        }

		private void DrawNormalRed()
		{
			LevelMaster.RegisterDrawable(red);
        }

		private void DrawDarkRed()
		{
			LevelMaster.RegisterDrawable(darkRed);
        }

		private void DrawBlackScreen()
		{
			LevelMaster.RegisterDrawable(blackScreen);
        }

		private void WriteWord()
		{
			LevelMaster.RegisterDrawable(text);
        }

		public void Update(GameTime gameTime)
		{
			if ((counter == 0) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
				DrawLinkSpinningOverlay();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                counter++;
			}

			/* The length of overlay where link is spinning is tentatively set to 3000, this should always be
			 * synchronized with Link to make sure LinkSpinningState and this screen have the same length.
			 */
            if ((counter == 1) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 3000))
			{
				DrawLightRed();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
            }

            if ((counter == 2) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
				DrawNormalRed();
				lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

            if ((counter == 3) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
				DrawDarkRed();
				lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

			/* Link should become black & white at this moment, when screen turns black, which is 4100 milliseconds
			 * after gameover screen starts to draw. This is a tentative number based on the time I used now.
			 */
			if ((counter == 4) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
				DrawBlackScreen();
				lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

			/* Link dissapearing animation should finish before word is written, 
			 * once again 800 here is a tentative time.
			 */
			if ((counter == 5) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 2000))
			{
				WriteWord();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                counter++;
			}

            if ((counter == 6) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 1000))
            {
				GameState.GetInstance().ResetGameState();
                counter++;
            }

        }
	}
}

