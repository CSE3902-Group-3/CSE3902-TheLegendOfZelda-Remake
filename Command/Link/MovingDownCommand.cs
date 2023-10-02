
namespace LegendOfZelda
{
    public class MovingDownCommand : ICommands
    {

        private IPlayer player;

        public MovingDownCommand(IPlayer link)
        {
            player = link;
        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new WalkDownLinkState());
            player.stateMachine.Update();
        }
    }
}
