using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowRightLinkState : IState
    {
        private Link Link;

        public ItemThrowRightLinkState()
        {
            this.Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowRightSprite();

            // Throw item
            if (Inventory.getInstance().SecondaryItem is Bomb)
            {
                new BombProjectile(Link.StateMachine.position + LinkUtilities.rightBombOffset);
            }
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(Link.StateMachine.position + LinkUtilities.rightBombOffset, Direction.right, Link);
            }
            else if (Inventory.getInstance().SecondaryItem is Candle)
            {
                new FireProjectile(Link.StateMachine.position + LinkUtilities.rightFireOffset, Direction.right);
            }
            else if (Inventory.getInstance().SecondaryItem is Bow)
            {
                if (Inventory.getInstance().GetQuantity(new Arrow(new Vector2(0, 0))) > 0)
                {
                    if (Inventory.getInstance().SpendRupee(1))
                    {
                        new ArrowProjectile(GameState.Link.StateMachine.position + LinkUtilities.leftRightSwordBeamOffset, GameState.Link.StateMachine.currentDirection);
                    }

                }
            }
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            Link.StateMachine.canMove = true;
            ((AnimatedSprite)Link.Sprite).UnregisterSprite();
        }

    }
}
