using LegendOfZelda;

namespace LegendOfZelda
{
    public class HurtLinkState : IState
    {
        private Game1 game;
        private Link link;

        public HurtLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            // cast then start flashing sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.flashing = true;
        }

        public void Execute()
        {
            // do nothing
            // lower health??
        }

        public void Exit()
        {
            // cast then stop flashing sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.flashing = false;
        }
    }
}
