
using Microsoft.Xna.Framework;
namespace LegendOfZelda
{
    public class UseSecondaryItemCommand : ICommands
    {
        public UseSecondaryItemCommand(){}

        public void Execute()
        {
            IItem secondaryItem = Inventory.getInstance().SecondaryItem;
            if (secondaryItem is Bomb || secondaryItem is Boomerang || secondaryItem is Candle || secondaryItem is Bow)
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
            else if (secondaryItem is Fairy || secondaryItem is Potion)
            {
                GameState.Link.Heal(GameState.Link.MaxHP);
            }
        }
    }
}
