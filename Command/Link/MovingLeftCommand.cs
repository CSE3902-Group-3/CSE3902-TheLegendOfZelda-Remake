
namespace LegendOfZelda
{
    public class MovingLeftCommand : ICommands
    {

        private IPlayer player;

        public MovingLeftCommand(IPlayer link)
        {
            player = link;
        }

        public void Execute()
        {
            player.StateMachine.ChangeState(new WalkLeftLinkState());
        }
    }
}
