
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        //Prepare for later use
        private IPlayer link;

        public ResetCommand(IPlayer link)
        {
            this.link = link;
        }

        public void Execute()
        {
            GameState.GetInstance().SwitchState(new GameOverState());
        }

    }
}
