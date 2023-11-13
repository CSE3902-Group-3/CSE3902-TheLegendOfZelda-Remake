using System;

namespace LegendOfZelda
{
    internal class ReturnFromItemMenuCommand : ICommands
    {
        public ReturnFromItemMenuCommand(){}
        public void Execute()
        {
            GameState.GetInstance().SetToNormal();
            CameraController.GetInstance().CloseItemMenu();
        }
    }
}
