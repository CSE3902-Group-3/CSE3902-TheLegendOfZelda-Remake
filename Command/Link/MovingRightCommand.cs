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
            player.stateMachine.ChangeState(new WalkRightLinkState(Game1.instance)); //Runtime Error when initialize controller in Initialize(): Object reference not set to an instance of an object.
            player.currentDirection = Player.Link.Direction.Right; //Does not contain a definition for currentDirection
        }

        public void Execute()
        {
            player.stateMachine.Update();
        }
    }
}
