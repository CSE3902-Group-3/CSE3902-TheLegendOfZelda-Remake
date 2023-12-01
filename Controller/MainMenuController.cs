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

            if (Keyboard.GetState().IsKeyDown(Keys.K) && ReleasedKey)
            {
                ShaderHolder.CyclePalletteBackward();
                ReleasedKey = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.L) && ReleasedKey)
            {
                ShaderHolder.CyclePalletteForward();
                ReleasedKey = false;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.K) && Keyboard.GetState().IsKeyUp(Keys.L) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
    }
}

