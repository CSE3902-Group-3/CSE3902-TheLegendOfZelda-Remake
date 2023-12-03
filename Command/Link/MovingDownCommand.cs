
namespace LegendOfZelda
{
    public class MovingDownCommand : ICommands
    {
        public MovingDownCommand(){}
        public void Execute()
        {
            GameState.Link.StateMachine.ChangeState(new WalkDownLinkState());
        }
    }
}
