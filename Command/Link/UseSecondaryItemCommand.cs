
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda
{
    public class UseSecondaryItemCommand : ICommands
    {
        private Link player;

        public UseSecondaryItemCommand()
        {
            this.player = GameState.Link;
        }

        public void Execute()
        {
            IItem secondaryItem = Inventory.getInstance().SecondaryItem;
            if (secondaryItem is Bomb || secondaryItem is Boomerang || secondaryItem is Candle || secondaryItem is Bow)
            {
                switch (player.StateMachine.currentDirection)
                {
                    case Direction.left:
                        player.StateMachine.ChangeState(new ItemThrowLeftLinkState());
                        break;
                    case Direction.up:
                        player.StateMachine.ChangeState(new ItemThrowUpLinkState());
                        break;
                    case Direction.right:
                        player.StateMachine.ChangeState(new ItemThrowRightLinkState());
                        break;
                    case Direction.down:
                        player.StateMachine.ChangeState(new ItemThrowDownLinkState());
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
