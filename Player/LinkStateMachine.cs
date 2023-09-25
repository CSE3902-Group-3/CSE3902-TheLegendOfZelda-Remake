using LegendOfZelda.Interfaces;

namespace LegendOfZelda.Player
{
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        IState prevState;
        IState currentState;

        public void ChangeState(IState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            prevState = currentState;
            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            // ICommand can handle changing the state, then we can just call LinkStateMachine.Update() in Game1.Update()
            currentState.Execute();
        }
    }
}
