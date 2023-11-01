using System;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class PauseController : IController
	{
        private PauseManager PauseManager;
        private ICommands UnpauseCommand;

        public PauseController(PauseManager pauseManager)
		{
            UnpauseCommand = new UnpauseCommand(pauseManager);
            PauseManager = pauseManager;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Space) && PauseManager.isPaused())
            {
                UnpauseCommand.Execute();
            }
        }
    }
}

