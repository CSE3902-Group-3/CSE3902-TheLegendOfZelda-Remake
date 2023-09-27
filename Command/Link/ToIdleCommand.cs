using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
    internal class ToIdleCommand : ICommands
    {
        private IPlayer player;

        public ToIdleCommand(IPlayer link)
        {
            player = link;

        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new IdleLinkState(Game1.instance));
        }
    }
}
