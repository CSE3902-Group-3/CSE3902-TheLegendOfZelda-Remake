using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.StateMachine.Link
{
    public class LinkState
    {
        public StateMachine linkState;

        public LinkState(StateMachine linkState, IState defaultLinkState)
        {
            this.linkState = linkState;
            linkState.ChangeState(defaultLinkState);
        }
    }
}
