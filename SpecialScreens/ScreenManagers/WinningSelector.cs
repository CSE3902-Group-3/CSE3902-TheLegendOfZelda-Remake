using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class WinningSelector
    {
        private List<IItem> IndicationHearts;
        private int selection;
        private int cameraXPos;
        private int cameraYPos;
        private Vector2 OptionOnePos;
        private Vector2 OptionTwoPos;
        private GraphicsDevice graphicsDevice;
        private int ScreenWidth;
        private int ScreenHeight;

        public WinningSelector()
        {
            cameraXPos = 30000;
            cameraYPos = 0;
            selection = 1;
            ScreenWidth = 1024;
            ScreenHeight = 896;
            graphicsDevice = Game1.getInstance().GraphicsDevice;
            OptionOnePos = new Vector2((cameraXPos + ScreenWidth / 4) - 40, cameraYPos + ScreenHeight / 3);
            OptionTwoPos = new Vector2((cameraXPos + ScreenWidth / 4) - 40, (cameraYPos + ScreenHeight) * 2 / 3);


            IndicationHearts = new List<IItem>()
            {
                new SelectionHeart(OptionOnePos),
                new SelectionHeart(OptionTwoPos)
            };

            foreach (IItem item in IndicationHearts)
            {
                item.Remove();
            }
        }

        public void nextOption()
        {
            IndicationHearts[selection].Remove();

            if (selection == 1)
            {
                selection = 0;
            }
            else
            {
                selection = 1;
            }

            IndicationHearts[selection].Show();
        }

        public void Reset()
        {
            IndicationHearts[selection].Remove();
            selection = 0;
            IndicationHearts[selection].Show();
        }

        public void ExecuteSelection()
        {
            if (selection == 0)
            {
                //To be added in the future
            }
            else if (selection == 1)
            {
                //To be added in the future
            }
        }
    }
}