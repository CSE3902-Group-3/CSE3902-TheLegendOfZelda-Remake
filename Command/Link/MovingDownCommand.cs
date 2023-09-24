using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class MovingDownCommand : ICommands
    {
        private Player.Link link;

        public MovingDownCommand(Player.Link link)
        {
            this.link = link;
            link.stateMachine.ChangeState(new WalkDownLinkState(Game1.instance));
            link.currentDirection = Player.Link.Direction.Down;
        }

        public void Execute()
        {
            link.stateMachine.Update();
        }
    }
}
