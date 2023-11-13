using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class GameOverMenuSelector
    {
        private List<IItem> IndicationHearts;
        private int selection;
        private int cameraXPos;
        private int cameraYPos;
        private Vector2 ContinuePos;
        private Vector2 SavePos;
        private Vector2 RetryPos;
        private GraphicsDevice graphicsDevice;
        private int lastCommand;

        public GameOverMenuSelector()
        {
            cameraXPos = 40000;
            cameraYPos = 0;
            selection = 1;
            graphicsDevice = Game1.getInstance().GraphicsDevice;
            ContinuePos = new Vector2((cameraXPos + graphicsDevice.Viewport.Width / 3) - 40, cameraYPos + graphicsDevice.Viewport.Height / 3);
            SavePos = new Vector2((cameraXPos + graphicsDevice.Viewport.Width / 3) - 40, cameraYPos + graphicsDevice.Viewport.Height / 2);
            RetryPos = new Vector2((cameraXPos + graphicsDevice.Viewport.Width / 3) - 40, (cameraYPos + graphicsDevice.Viewport.Height) * 2 / 3);


            IndicationHearts = new List<IItem>()
            {
                new SelectionHeart(ContinuePos),
                //new Heart(SavePos),
                new SelectionHeart(RetryPos)
            };

            foreach (IItem item in IndicationHearts)
            {
                item.Remove();
            }

            //IndicationHearts[selection].Show();

        }

        public void nextOption()
        {
            IndicationHearts[selection].Remove();

            if (selection == IndicationHearts.Count - 1)
            {
                selection = 0;
            }
            else
            {
                selection++;
            }

            IndicationHearts[selection].Show();
        }

        /*public void previousOption()
        {
            IndicationHearts[selection].Remove();

            if (selection == 0)
            {
                selection = IndicationHearts.Count - 1;
            }
            else
            {
                selection--;
            }

            IndicationHearts[selection].Show();
        }*/

        public void Reset()
        {
            IndicationHearts[selection].Remove();
            selection = 0;
            IndicationHearts[selection].Show();
        }

        public void ExecuteSelection()
        {
            if (selection == 0) GameState.GetInstance().SwitchState(new NormalState());
            if (selection == 1) GameState.GetInstance().ResetGameState();

            GameState.CameraController.ChangeMenu(Menu.Start);
        }
    }
}