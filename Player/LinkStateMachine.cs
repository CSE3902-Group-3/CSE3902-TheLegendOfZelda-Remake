using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LinkStateMachine
    {
        // might be useful for one frame states like throwing an item
        public IState PrevState { get; private set; }
        public IState CurrentState { get; private set; }

        public bool canMove { get; set; } = true;
        public bool isWalking { get; set; } = false;
        public Direction currentDirection { get; set; } = Direction.right;


        public Vector2 position = new Vector2(0,0);
        public Direction prevDirection;

        public Inventory linkInventory { get; set; }
        public IItem currentItem { get; set; }
        public bool isTakingDamage { get; set; }

        public void ChangeState(IState newState)
        {
            if (LinkUtilities.IsStateWithIncompleteAnimation(this.CurrentState)) return;
            // only change if states are different
            if (CurrentState != null && (newState.GetType() == CurrentState.GetType())) return;

            Link link = (Link)Game1.getInstance().link;
            if(link != null)
            {
                position = link.sprite.pos;
            }

            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            PrevState = CurrentState;
            CurrentState = newState;
            CurrentState.Enter();

            if(link != null)
            {
                link.sprite.UpdatePos(position);
            }
        }

        public void Update()
        {
            CurrentState.Execute();
        }
    }
}
