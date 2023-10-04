using LegendOfZelda;

namespace LegendOfZelda
{
    public class ItemThrowLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowLeftLinkState()
        {
            this.game = Game1.getInstance();
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowLeftSprite();
        }

        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
            AnimatedSprite spriteAlias = (AnimatedSprite)this.link.sprite;
            spriteAlias.UnregisterSprite();
        }

    }
}
