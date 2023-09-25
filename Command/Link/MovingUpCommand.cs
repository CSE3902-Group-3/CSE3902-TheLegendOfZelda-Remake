using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class MovingUpCommand : ICommands
    {
        private Player.Link link;

        public MovingUpCommand(Player.Link link)
        {
            this.link = link;
            link.stateMachine.ChangeState(new WalkUpLinkState(Game1.instance));
            link.currentDirection = Player.Link.Direction.Up;
        }

        public void Execute()
        {
            //link.stateMachine.Update();
        }
    }
}
