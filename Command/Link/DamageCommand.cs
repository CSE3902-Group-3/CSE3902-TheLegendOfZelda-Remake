using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class DamageCommand : ICommands
    {
        //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.

        private IPlayer player;

        public DamageCommand(IPlayer link)
        {
            player = link;

        }

        public void Execute()
        {
            player.stateMachine.ChangeState(new HurtLinkState(Game1.instance));
        }
    }
}
