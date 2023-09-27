using LegendOfZelda;

namespace LegendOfZelda
{
    public class MovingLeftCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
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
