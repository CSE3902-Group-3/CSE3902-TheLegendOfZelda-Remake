using LegendOfZelda.Interfaces;

namespace LegendOfZelda.StateMachine.Link.LinkStates
{
    public class WalkingLinkState : IState
    {
        //private Link link;

        public WalkingLinkState(/*Link link*/)
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
