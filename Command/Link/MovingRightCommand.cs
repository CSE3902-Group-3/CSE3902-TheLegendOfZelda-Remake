using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class MovingRightCommand : ICommands
    {
        private Player.Link link;

        public MovingRightCommand(Player.Link link)
        {
            this.link = link;
            link.stateMachine.ChangeState(new WalkRightLinkState(Game1.instance));
            link.currentDirection = Player.Link.Direction.Right;
        }

        public void Execute()
        {
            link.stateMachine.Update();
        }
    }
}
