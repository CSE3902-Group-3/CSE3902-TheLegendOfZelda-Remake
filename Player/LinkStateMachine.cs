using LegendOfZelda.Interfaces;
using LegendOfZelda.StateMachine.LinkStates.Walk;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.Player
{
    //Modified last minute by Michael to meet functionality deadline. Original author still needs to come back and finish
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        IState prevState;
        IState currentState;

        // used for states like hurt, where we just want to apply a sprite affect
        IState superState;
        Vector2 position = new Vector2(0,0);

        public void ChangeState(IState newState)
        {
            if (newState is WalkDownLinkState && currentState is WalkDownLinkState) return;
            if (newState is WalkRightLinkState && currentState is WalkRightLinkState) return;
            if (newState is WalkLeftLinkState && currentState is WalkLeftLinkState) return;
            if (newState is WalkUpLinkState && currentState is WalkUpLinkState) return;


            Link link = (Link)Game1.instance.link;
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
