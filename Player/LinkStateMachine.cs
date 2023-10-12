using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    //Modified last minute by Michael to meet functionality deadline. Original author still needs to come back and finish
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        IState prevState;
        IState currentState;

        public Vector2 position = new Vector2(0,0);

        public void ChangeState(IState newState)
        {
            // only change if states are different
            if (currentState != null && (newState.GetType() == currentState.GetType())) return;

            Link link = (Link)Game1.getInstance().link;
            if(link != null)
            {
                position = link.sprite.pos;
            }
            
            if (currentState != null)
            {
                currentState.Exit();
            }

            prevState = currentState;
            currentState = newState;
            currentState.Enter();

            if(link != null)
            {
                link.sprite.UpdatePos(position);
            }
            
        }

        public void Update()
        {
            // ICommand can handle changing the state, then we can just call LinkStateMachine.Update() in Game1.Update()
            currentState.Execute();
        }
    }
}
