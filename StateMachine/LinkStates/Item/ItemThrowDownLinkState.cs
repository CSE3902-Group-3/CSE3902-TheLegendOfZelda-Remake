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
                new BombProjectile(Link.StateMachine.position + new Vector2(30, 150));
            } 
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(Link.StateMachine.position + new Vector2(30, 150), new Vector2(0, -1), Link);
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
