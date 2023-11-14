namespace LegendOfZelda.Command.ItemMenu
{
    internal class GoToItemMenuCommand : ICommands
    {
        public GoToItemMenuCommand() { }
        public void Execute()
        {
            GameState.GetInstance().SwitchState(new ItemMenuState());
            CameraController.GetInstance().OpenItemMenu();
        }
    }
}
