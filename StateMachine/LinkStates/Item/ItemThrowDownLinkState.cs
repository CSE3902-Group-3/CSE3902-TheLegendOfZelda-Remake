using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowDownLinkState : IState
    {
        private Link Link;

        public ItemThrowDownLinkState()
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
            Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowDownSprite();

            // Throw item
            if (Inventory.getInstance().SecondaryItem is Bomb)
            {
                new BombProjectile(Link.StateMachine.position + LinkUtilities.downBombOffset);
            }
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(Link.StateMachine.position + LinkUtilities.downBombOffset, Direction.down, Link);
            } else if (Inventory.getInstance().SecondaryItem is Candle)
            {
                new FireProjectile(Link.StateMachine.position + LinkUtilities.downFireOffset, Direction.down);
            } 
            else if (Inventory.getInstance().SecondaryItem is Bow)
            {
                if (Inventory.getInstance().GetQuantity(new Arrow(new Vector2(0, 0))) > 0)
                {
                    if (Inventory.getInstance().SpendRupee(1))
                    {
                        new ArrowProjectile(GameState.Link.StateMachine.position + LinkUtilities.downSwordBeamOffset, GameState.Link.StateMachine.currentDirection);
                    }

                }
            }
        }

        public void Execute()
        {
            if (((AnimatedSprite)Link.Sprite).complete)
            {
                Link.StateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            Link.StateMachine.canMove = true;
            ((AnimatedSprite)Link.Sprite).UnregisterSprite();
        }

    }
}
