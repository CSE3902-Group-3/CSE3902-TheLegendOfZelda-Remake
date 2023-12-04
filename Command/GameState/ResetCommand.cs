
namespace LegendOfZelda
{
    public class ResetCommand : ICommands
    {
        public ResetCommand(){}

        public void Execute()
        {
            GameState.Link.Die();
        }

    }
}
