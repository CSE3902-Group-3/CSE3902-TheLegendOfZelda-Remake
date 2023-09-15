using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class AttackingLInkState : IState
    {
        //private Link link;

        public AttackingLInkState(/*Link link*/)
        {
            //this.link = link;
        }

        public void Enter()
        {
            // swap to sprite with weapon
            // start walking animation in direction

            // update velocity if prevState was idle
        }

        public void Execute()
        {
            // change animation dir based on input
            // animate based on input
        }

        public void Exit()
        {
            // 
        }

    }
}
