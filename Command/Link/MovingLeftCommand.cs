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
            player.stateMachine.ChangeState(new WalkLeftLinkState(Game1.instance)); //Runtime Error when initialize controller in Initialize(): Object reference not set to an instance of an object.
            //player.currentDirection = Player.Link.Direction.Left; //Does not contain a definition for currentDirection
        }

        public void Execute()
        {
            player.stateMachine.Update();
        }
    }
}
