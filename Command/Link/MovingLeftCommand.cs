
namespace LegendOfZelda
{
    public class MovingLeftCommand : ICommands
    {
        public MovingLeftCommand(){}
        public void Execute()
        {
            GameState.Link.StateMachine.ChangeState(new WalkLeftLinkState());
        }
    }
}
