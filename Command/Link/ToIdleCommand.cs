
namespace LegendOfZelda
{
    public class ToIdleCommand : ICommands
    {
        public ToIdleCommand(){}

        public void Execute()
        {
            GameState.Link.StateMachine.ChangeState(new IdleLinkState());
        }
    }
}
