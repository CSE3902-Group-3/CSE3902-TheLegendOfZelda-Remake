
namespace LegendOfZelda
{
    public class MovingUpCommand : ICommands
    {

        private IPlayer player;

        public MovingUpCommand(IPlayer link)
        {
            player = link;
            
        }

        public void Execute()
        {
            player.StateMachine.ChangeState(new WalkUpLinkState());
        }
    }
}
