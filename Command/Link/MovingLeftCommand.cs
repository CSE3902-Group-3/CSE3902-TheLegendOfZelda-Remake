
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
            player.stateMachine.ChangeState(new WalkLeftLinkState());
            player.stateMachine.Update();
        }
    }
}
