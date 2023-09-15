using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class HurtLinkState : IState
    {
        //private Link link;

        public HurtLinkState(/*Link link*/)
        {
            //this.link = link;
        }

        public void Enter()
        {
            // change sprites to hurt link

            // start walking animation in direction
            // update velocity if prevState was idle
        }

        public void Execute()
        {
            // update damaged sprite effects?
            // change animation dir based on input
        }

        public void Exit()
        {
            // remove hurt sprite effects
        }
    }
}
