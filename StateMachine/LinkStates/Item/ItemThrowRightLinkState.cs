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
                new BombProjectile(Link.StateMachine.position + LinkUtilities.rightItemOffset);
            }
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(Link.StateMachine.position + LinkUtilities.rightItemOffset, LinkUtilities.rightDirVector, Link);
            }
            else if (Inventory.getInstance().SecondaryItem is Candle)
            {
                new FireProjectile(Link.StateMachine.position + LinkUtilities.rightItemOffset, Direction.right);
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
