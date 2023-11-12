using System;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class MainMenuController : IController
    {
        private ICommands StartGameCommand;
        private bool ReleasedKey;

        public MainMenuController()
        {
            StartGameCommand = new StartGameCommand();
            ReleasedKey = false;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && ReleasedKey)
            {
                StartGameCommand.Execute();
                ReleasedKey = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Enter) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
    }
}

