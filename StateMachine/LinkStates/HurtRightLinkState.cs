using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class HurtRightLinkState : IState
    {
        private Game1 game { get; set; }
        private Link link { get; set; }

        public HurtLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)this.game.link;
        }

        public void Enter()
        {
            // cast then start flashing sprite
            AnimatedSprite sprite = (AnimatedSprite)link.sprite;
            sprite.flashing = true;
        }

        public void Execute()
        {
            // do nothing
            // lower health??
        }

        public void Exit()
        {
            // cast then stop flashing sprite
            AnimatedSprite sprite = (AnimatedSprite)link.sprite;
            sprite.flashing = false;
        }
    }
}
