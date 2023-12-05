
using Microsoft.Xna.Framework;
namespace LegendOfZelda
{
    public class UseSecondaryItemCommand : ICommands
    {
        public UseSecondaryItemCommand(){}

        public void Execute()
        {
            IItem secondaryItem = Inventory.getInstance().SecondaryItem;
            if (secondaryItem is Bomb || secondaryItem is Boomerang)
            {
                switch (GameState.Link.StateMachine.currentDirection)
                {
                    case Direction.left:
                        GameState.Link.StateMachine.ChangeState(new ItemThrowLeftLinkState());
                        break;
                    case Direction.up:
                        GameState.Link.StateMachine.ChangeState(new ItemThrowUpLinkState());
                        break;
                    case Direction.right:
                        GameState.Link.StateMachine.ChangeState(new ItemThrowRightLinkState());
                        break;
                    case Direction.down:
                        GameState.Link.StateMachine.ChangeState(new ItemThrowDownLinkState());
                        break;
                }
            }
            else if (secondaryItem is Bow)
            {
                if (Inventory.getInstance().GetQuantity(new Arrow(new Vector2(0,0)))> 0)
                {
                    if (Inventory.getInstance().SpendRupee(1))
                    {
                        new ArrowProjectile(GameState.Link.StateMachine.position, GameState.Link.StateMachine.currentDirection);
                    }

                }
            }
            else if (secondaryItem is Fairy || secondaryItem is Potion)
            {
                GameState.Link.Heal(GameState.Link.MaxHP);
            }
        }
    }
}
