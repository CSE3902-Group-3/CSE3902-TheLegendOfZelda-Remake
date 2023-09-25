using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;

namespace LegendOfZelda.Command.Link
{
    public class MovingDownCommand : ICommands
    {
        private IPlayer player;

        public MovingDownCommand(IPlayer link)
        {
            player = link;
            player.stateMachine.ChangeState(new WalkDownLinkState(Game1.instance)); //Runtime Error when initialize controller in Initialize(): Object reference not set to an instance of an object.
            //player.currentDirection = Player.Link.Direction.Down; //Does not contain a definition for currentDirection
        }

        public void Execute()
        {
            player.stateMachine.Update();
        }
    }
}
