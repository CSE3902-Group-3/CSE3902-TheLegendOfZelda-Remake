using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class MovingLeftCommand : ICommands
    {
        private Player.Link link;

        public MovingLeftCommand(Player.Link link)
        {
            this.link = link;
            link.stateMachine.ChangeState(new WalkLeftLinkState(Game1.instance));
            link.currentDirection = Player.Link.Direction.Left;
        }

        public void Execute()
        {
            //link.stateMachine.Update();
        }
    }
}
