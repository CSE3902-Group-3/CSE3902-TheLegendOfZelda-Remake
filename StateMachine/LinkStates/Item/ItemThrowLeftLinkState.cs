using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class ItemThrowLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowLeftLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkThrowLeftSprite();
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
