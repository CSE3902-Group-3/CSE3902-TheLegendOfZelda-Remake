using LegendOfZelda;

namespace LegendOfZelda
{
    public class ItemThrowDownLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowDownLinkState()
        {
            this.game = Game1.getInstance();
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.stateMachine.canMove = false;
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowDownSprite();
        }

        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;

            if (((AnimatedSprite)link.sprite).complete)
            {
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
            ((AnimatedSprite)link.sprite).UnregisterSprite();
        }

    }
}
