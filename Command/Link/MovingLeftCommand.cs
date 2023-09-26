using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;

namespace LegendOfZelda.Command.Link
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
            player.stateMachine.ChangeState(new WalkLeftLinkState(Game1.instance));
            player.stateMachine.Update();
        }
    }
}
