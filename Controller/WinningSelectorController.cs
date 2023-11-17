using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class WinningSelectorController : IController
    {
        private NextWinningSelectionCommand nextSelectionCommand;
        private ExecuteWinningSelectionCommand selectionCommand;
        private bool ReleasedKey;
        private bool initialized;

        public WinningSelectorController()
        {
            nextSelectionCommand = new NextWinningSelectionCommand();
            selectionCommand = new ExecuteWinningSelectionCommand();
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

