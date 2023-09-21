using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.Link
{
    public class PrimaryAttackCommand : ICommands
    {
        SpriteFactory spriteFactory;
        AnimatedSprite link;
        //Prepare for later use
        private IState linkState;

        public void Execute()
        {
            //Prepare for later
        }
    }
}
