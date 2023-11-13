using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    public class ItemMenuController : IController
    {
        private ICommands ReturnFromItemMenuCommand;
        private bool ReleasedKey;

        public ItemMenuController()
        {
            ReleasedKey = false;
            ReturnFromItemMenuCommand = new ReturnFromItemMenuCommand();
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.M) && ReleasedKey)
            {
                ReturnFromItemMenuCommand.Execute();
                ReleasedKey = false;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.M) && !ReleasedKey)
            {
                ReleasedKey = true;
            }
        }
    }
}
