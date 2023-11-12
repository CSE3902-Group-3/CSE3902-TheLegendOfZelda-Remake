using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MainMenu
    {
        private AnimatedSprite menuScreen;

        public MainMenu()
        {
            menuScreen = SpriteFactory.getInstance().CreateMainMenuSprite();
            menuScreen.UpdatePos(CameraController.GetInstance().StartLocation);
        }

    }
}
