
namespace LegendOfZelda
{
    public class MovingRightCommand : ICommands
    {
        public MovingRightCommand(){}

        public void Execute()
        {
            GameState.Link.StateMachine.ChangeState(new WalkRightLinkState());
        }
    }
}
