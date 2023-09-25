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
            player.stateMachine.ChangeState(new WalkUpLinkState(Game1.instance)); //Runtime Error when initialize controller in Initialize(): Object reference not set to an instance of an object.
            //player.currentDirection = Player.Link.Direction.Up; //Does not contain a definition for currentDirection
        }

        public void Execute()
        {
            player.stateMachine.Update();
        }
    }
}
