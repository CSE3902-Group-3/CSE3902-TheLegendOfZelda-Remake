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
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowDownSprite();
        }

        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {
        }

    }
}
