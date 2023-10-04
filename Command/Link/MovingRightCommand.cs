
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
            player.stateMachine.ChangeState(new WalkRightLinkState());
            player.stateMachine.Update();
        }
    }
}
