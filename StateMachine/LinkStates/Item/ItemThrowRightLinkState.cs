using LegendOfZelda;

namespace LegendOfZelda
{
    public class ItemThrowRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowRightLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkThrowRightSprite();
        }

        public void Execute()
        {
            // do nothing
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
            AnimatedSprite spriteAlias = (AnimatedSprite)this.link.sprite;
            spriteAlias.UnregisterSprite();
        }

    }
}
