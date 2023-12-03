namespace LegendOfZelda
{
    public class StartGameCommand : ICommands
    {

        public StartGameCommand()
        {

        }

        public void Execute()
        {
            CameraController.GetInstance().ChangeMenu(Menu.Item);
            GameState.GetInstance().SwitchState(new LevelTransitionState(2));
        }
    }
}
