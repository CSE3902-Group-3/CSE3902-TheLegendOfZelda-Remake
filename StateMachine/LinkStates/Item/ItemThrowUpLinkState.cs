using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowUpLinkState : IState
    {
        private Link Link;

        public ItemThrowUpLinkState()
        {
            Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowUpSprite();

            // Throw item
            if (Inventory.getInstance().SecondaryItem is Bomb)
            {
                new BombProjectile(Link.StateMachine.position + new Vector2(-30, 150));
            }
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(Link.StateMachine.position + new Vector2(-30, 150), new Vector2(0, 1), Link);
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
