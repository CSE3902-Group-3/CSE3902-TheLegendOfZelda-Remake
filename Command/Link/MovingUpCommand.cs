
namespace LegendOfZelda
{
    public class MovingUpCommand : ICommands
    {
        public MovingUpCommand(){}

        public void Execute()
        {
            GameState.Link.StateMachine.ChangeState(new WalkUpLinkState());
        }
    }
}
