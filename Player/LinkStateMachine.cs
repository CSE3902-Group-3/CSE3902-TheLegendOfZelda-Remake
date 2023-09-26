using LegendOfZelda.Interfaces;

namespace LegendOfZelda.Player
{
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        IState prevState;
        IState currentState;

        // used for states like hurt, where we just want to apply a sprite affect
        IState superState;

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

        public void ApplySuperState(IState newState)
        {
            superState = newState;
            superState.Enter();
        }

        public void RemoveSuperState()
        {
            superState.Exit();
            superState = null;
        }

        public void Update()
        {
            // ICommand can handle changing the state, then we can just call LinkStateMachine.Update() in Game1.Update()
            currentState.Execute();
        }
    }
}
