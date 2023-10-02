using LegendOfZelda;

namespace LegendOfZelda
{
    public class MovingUpCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
        private IPlayer player;

        public MovingUpCommand(IPlayer link)
        {
            player = link;
            
        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new WalkUpLinkState());
            player.stateMachine.Update();
        }
    }
}
