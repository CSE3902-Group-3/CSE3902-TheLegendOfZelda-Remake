using System;

namespace LegendOfZelda
{
    internal class ReturnFromItemMenuCommand : ICommands
    {
        public ReturnFromItemMenuCommand(){}
        public void Execute()
        {
            CameraController.GetInstance().CloseItemMenu(GameState.GetInstance().SetToNormal);
        }
    }
}
