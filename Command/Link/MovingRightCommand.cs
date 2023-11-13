
namespace LegendOfZelda
{
    public class MovingRightCommand : ICommands
    {

        private IPlayer player;

        public MovingRightCommand(IPlayer link)
        {
            this.player = link;
        }

        public void Execute()
        {
            player.StateMachine.ChangeState(new WalkRightLinkState());
        }
    }
}
