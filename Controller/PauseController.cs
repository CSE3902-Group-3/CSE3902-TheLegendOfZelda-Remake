using System;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class PauseController : IController
	{
        private ICommands pauseCommand;
        private bool isPPressed;
        private PauseManager pauseManager;

        public PauseController()
		{
            pauseManager = Game1.getInstance().pauseManager;
            pauseCommand = new PauseCommand(pauseManager);
            isPPressed = false;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !isPPressed)
            {
                pauseCommand.Execute();
                isPPressed = true;
            }

            isPPressed = !Keyboard.GetState().IsKeyUp(Keys.Space);
        }
    }
}

