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
            int levelNumber = int.Parse(Game1.getInstance().ReadConfig.GameConfig["Game.Level"]);
            GameState.GetInstance().SwitchState(new LevelTransitionState(levelNumber));
        }
    }
}
