using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class IdleLinkState : IState
    {
        //private Link link;

        public IdleLinkState (/*Link link*/)
        {
            //this.link = link;
        }

        public void Enter()
        {
            // pause animation
            // velocity = 0
        }

        public void Exit()
        {

        }
    }
}
