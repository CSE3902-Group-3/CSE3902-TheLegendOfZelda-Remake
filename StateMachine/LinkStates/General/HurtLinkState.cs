using LegendOfZelda;

namespace LegendOfZelda
{
    public class HurtLinkState : IState
    {
        private Game1 game;
        private Link link;

        public HurtLinkState()
        {
            this.game = Game1.getInstance();
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            // cast then start flashing sprite
            ((AnimatedSprite)link.sprite).flashing = true;
        }

        public void Execute()
        {
            // do nothing
            // lower health??
        }

        public void Exit()
        {
            // cast then stop flashing sprite
            ((AnimatedSprite)link.sprite).flashing = false;
        }
    }
}
