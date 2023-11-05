using System;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class MainMenuController : IController
    {
        private MainMenuManager MainMenuManager;
        private ICommands StartCommand;
        private bool ReleasedKey;

        public MainMenuController(MainMenuManager mainMenuManager)
        {
            StartCommand = new StartCommand(mainMenuManager);
            MainMenuManager = mainMenuManager;
            ReleasedKey = false;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && PauseManager.isPaused() && ReleasedKey)
            {
                StartCommand.Execute();
                ReleasedKey = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
    }
}

