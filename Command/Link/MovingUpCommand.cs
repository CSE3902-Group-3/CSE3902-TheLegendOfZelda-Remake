using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;

namespace LegendOfZelda.Command.Link
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
            player.stateMachine.ChangeState(new WalkUpLinkState(Game1.instance));
            player.stateMachine.Update();
        }
    }
}
