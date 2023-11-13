﻿using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class GameOverMenuController : IController
    {
        private NextSelectionCommand nextSelectionCommand;
        private PreviousSelectionCommand previousSelectionCommand;
        private ExecuteSelectionCommand selectionCommand;
        private bool ReleasedKey;
        private bool initialized;

        public GameOverMenuController()
        {
            nextSelectionCommand = new NextSelectionCommand();
            previousSelectionCommand = new PreviousSelectionCommand();
            selectionCommand = new ExecuteSelectionCommand();
            ReleasedKey = false;
            initialized = false;
        }

        public void Update()
        {
            if (!initialized)
            {
                nextSelectionCommand.Execute();
                initialized = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.U) && ReleasedKey)
            {
                nextSelectionCommand.Execute();
                ReleasedKey = false;
            }
            /*if (Keyboard.GetState().IsKeyDown(Keys.I) && ReleasedKey)
            {
                previousSelectionCommand.Execute();
                ReleasedKey = false;
            }*/
            if (Keyboard.GetState().IsKeyUp(Keys.U) && /*Keyboard.GetState().IsKeyUp(Keys.I) && */!ReleasedKey)
            {
                ReleasedKey = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                selectionCommand.Execute();
            }
        }
    }
}

