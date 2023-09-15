using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class ItemUseLinkState : IState
    {
        //private Link link;

        public ItemUseLinkState(/*Link link*/)
        {
            //this.link = link;
        }

        public void Enter()
        {
            // start walking animation in direction
            // update velocity if prevState was idle
        }

        public void Execute()
        {
            // change animation dir based on input
        }

        public void Exit()
        {
            // 
        }

    }
}
