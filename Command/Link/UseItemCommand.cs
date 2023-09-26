using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
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
        private Player.Link player;

        public UseItemCommand(Player.Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseItem();
        }
    }
}
