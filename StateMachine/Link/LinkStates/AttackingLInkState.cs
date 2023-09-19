using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class AttackingLinkState : IState
    {
        //private Link link;

        public AttackingLinkState(/*Link link*/)
        {
            //this.link = link;
        }

        public void Enter()
        {
            // swap to sprite with weapon
            // start walking animation in direction

            // update velocity if prevState was idle
        }

        public void Exit()
        {
            // 
        }

    }
}
