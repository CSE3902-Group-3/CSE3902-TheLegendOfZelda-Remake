using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;

namespace LegendOfZelda.Command.Link
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
            player.stateMachine.ChangeState(new WalkRightLinkState(Game1.instance));
            player.stateMachine.Update();
        }
    }
}
