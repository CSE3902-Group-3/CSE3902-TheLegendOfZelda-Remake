namespace LegendOfZelda
{
    public class StartGameCommand : ICommands
    {

        public StartGameCommand()
        {

        }

        public void Execute()
        {
            GameState.GetInstance().SwitchState(new NormalState());
            CameraController.GetInstance().ChangeMenu(Menu.Item);
        }
    }
}
