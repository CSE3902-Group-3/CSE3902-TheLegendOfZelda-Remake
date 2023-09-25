using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.General;

namespace LegendOfZelda.Command.Link
{
    internal class IdleCommand : ICommands
    {
        private IPlayer player;

        public IdleCommand(IPlayer link)
        {
            player = link;
            player.stateMachine.ChangeState(new IdleLinkState(Game1.instance)); //Runtime Error when initialize controller in Initialize(): Object reference not set to an instance of an object.
        }

        public void Execute()
        {
        }
    }
}
