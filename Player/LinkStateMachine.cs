using LegendOfZelda.Interfaces;

namespace LegendOfZelda.Player
{
    public class LinkStateMachine
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
            if (currentState != null)
            {
                currentState.Execute();
            }
        }
    }
}
