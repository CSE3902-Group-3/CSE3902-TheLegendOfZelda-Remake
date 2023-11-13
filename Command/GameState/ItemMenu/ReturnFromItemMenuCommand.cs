namespace LegendOfZelda
{
    internal class ReturnFromItemMenuCommand : ICommands
    {
        public ReturnFromItemMenuCommand(){}
        public void Execute()
        {
            GameState.GetInstance().SwitchState(new NormalState());
            CameraController.GetInstance().CloseItemMenu();
        }
    }
}
