
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda
{
    public class UseSecondaryItemCommand : ICommands
    {
        private Link player;

        public UseSecondaryItemCommand(Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            IItem secondaryItem = Inventory.getInstance().SecondaryItem;
            if (secondaryItem is Bomb || secondaryItem is Boomerang)
            {
                switch (player.stateMachine.currentDirection)
                {
                    case Direction.left:
                        player.stateMachine.ChangeState(new ItemThrowLeftLinkState());
                        break;
                    case Direction.up:
                        player.stateMachine.ChangeState(new ItemThrowUpLinkState());
                        break;
                    case Direction.right:
                        player.stateMachine.ChangeState(new ItemThrowRightLinkState());
                        break;
                    case Direction.down:
                        player.stateMachine.ChangeState(new ItemThrowDownLinkState());
                        break;
                }
            }
            else if (secondaryItem is Bow)
            {
                if (Inventory.getInstance().GetQuantity(new Arrow(new Vector2(0,0)))> 0)
                {
                    if (Inventory.getInstance().SpendRupee(1))
                    {
                        new ArrowProjectile(Link.getInstance().stateMachine.position, Link.getInstance().stateMachine.currentDirection);
                    }

                }
            }
            else if (secondaryItem is Fairy || secondaryItem is Potion)
            {
                Link.getInstance().Heal(Link.getInstance().maxHP);
            }
        }
    }
}
