using System;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class PauseController : IController
	{
        private PauseManager PauseManager;
        private ICommands UnpauseCommand;
        private bool ReleasedKey;

        public PauseController(PauseManager pauseManager)
		{
            UnpauseCommand = new UnpauseCommand(pauseManager);
            PauseManager = pauseManager;
            ReleasedKey = false;
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && PauseManager.isPaused() && ReleasedKey)
            {
                UnpauseCommand.Execute();
                ReleasedKey = false;
            } 
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
    }
}

