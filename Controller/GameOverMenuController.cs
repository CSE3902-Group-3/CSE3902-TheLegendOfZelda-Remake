using Microsoft.Xna.Framework.Input;

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

            if ((Keyboard.GetState().IsKeyDown(Keys.RightShift) || Keyboard.GetState().IsKeyDown(Keys.LeftShift)) && ReleasedKey)
            {
                nextSelectionCommand.Execute();
                ReleasedKey = false;
            }
            /*if (Keyboard.GetState().IsKeyDown(Keys.I) && ReleasedKey)
            {
                previousSelectionCommand.Execute();
                ReleasedKey = false;
            }*/
            if (Keyboard.GetState().IsKeyUp(Keys.RightShift) && Keyboard.GetState().IsKeyUp(Keys.LeftShift) && !ReleasedKey)
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

