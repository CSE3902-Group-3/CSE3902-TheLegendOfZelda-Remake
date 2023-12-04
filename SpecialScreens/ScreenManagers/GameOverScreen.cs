using Microsoft.Xna.Framework;
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
		public GameOverMenu menu;
		private bool activated;
		public bool done;

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
			menu = new GameOverMenu();
			activated = false;
			done = false;
        }

		public void ActivateGameOver()
		{
			LevelManager.AddUpdateable(this);
			activated = true;
		}

		private void DrawLinkSpinningOverlay()
		{
			LevelManager.AddDrawable(linkSpinningOverlay);
        }

		private void DrawLightRed()
		{
			LevelManager.AddDrawable(lightRed);
        }

		private void DrawNormalRed()
		{
			LevelManager.AddDrawable(red);
        }

		private void DrawDarkRed()
		{
			LevelManager.AddDrawable(darkRed);
        }

		private void DrawBlackScreen()
		{
			LevelManager.AddDrawable(blackScreen);
        }

		private void WriteWord()
		{
			text.Draw();
        }

		public void UnactivateGameOverScreen()
		{
			if (activated)
			{
				LevelManager.RemoveDrawable(linkSpinningOverlay);
				LevelManager.RemoveDrawable(lightRed);
				LevelManager.RemoveDrawable(red);
				LevelManager.RemoveDrawable(darkRed);
				LevelManager.RemoveDrawable(blackScreen);
				LevelManager.RemoveDrawable(text);
                LevelManager.RemoveUpdateable(this);
				text.Remove();
                activated = false;
			}
		}

		public void Update(GameTime gameTime)
		{
			if ((counter == 0) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 100))
            {
				activated = true;
				DrawLinkSpinningOverlay();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                counter++;
			}

            if ((counter == 1) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 2800))
			{
				DrawLightRed();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
            }

            else if ((counter == 2) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
				DrawNormalRed();
				lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

            else if ((counter == 3) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
				DrawDarkRed();
				lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

			/* Link should become black & white at this moment, when screen turns black, which is 4100 milliseconds
			 * after gameover screen starts to draw. This is a tentative number based on the time I used now.
			 */
			else if ((counter == 4) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 500))
			{
                DrawBlackScreen();
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
				counter++;
			}

			/* Link dissapearing animation should finish before word is written, 
			 * once again 800 here is a tentative time.
			 */
			else if ((counter == 5) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 2000))
			{
                WriteWord();
				GameState.CameraController.ChangeMenu(Menu.GameOver);
                lastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                counter++;
			}

            else if ((counter == 6) && (gameTime.TotalGameTime.TotalMilliseconds > lastUpdate + 2000))
			{
				UnactivateGameOverScreen();
				menu.Draw();
				done = true;
				counter++;
			}
        }
	}
}