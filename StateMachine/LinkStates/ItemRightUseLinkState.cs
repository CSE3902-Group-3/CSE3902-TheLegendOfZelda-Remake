using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class ItemRightUseLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemRightUseLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkWoodStabRightSprite();
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
