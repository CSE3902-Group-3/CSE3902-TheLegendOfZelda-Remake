using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.Interfaces;

namespace LegendOfZelda.StateMachine
{
    public class StateMachine
    {
        IState currentState;

        public void ChangeState(IState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            // update will be handled by ICommand
            // StateMachine will control valid state switches and sprite/related changes
            // but player movement will be handled by ICommmand
        }
    }
}
