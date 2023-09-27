using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    //Class completed last minute in order to meet functionality check. Original author still needs to come back and finish the class.
    public class UseItemCommand : ICommands
    {
        /*
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        //Prepare for later use
        private IState linkState;
        */
        private Link player;

        public UseItemCommand(Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseItem();
        }
    }
}
