using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class AttackingRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public AttackingRightLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            // swap to sprite with weapon
            // start walking animation in direction

            // update velocity if prevState was idle
        }
        public void Execute()
        {
            
        }

        public void Exit()
        {
            // 
        }

    }
}
