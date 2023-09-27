using LegendOfZelda;

namespace LegendOfZelda
{
    internal class IdleCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.

        private IPlayer player;

        public IdleCommand(IPlayer link)
        {
            player = link;
            
        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new IdleLinkState(Game1.instance));
        }
    }
}
