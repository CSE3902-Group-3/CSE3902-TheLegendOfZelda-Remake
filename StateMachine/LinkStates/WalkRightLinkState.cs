using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using System.Numerics;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class WalkRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkRightLinkState(Game1 game, Link link)
        {
            this.game = game;
            this.link = link;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkWalkRightSprite();
        }

        public void Walk()
        {
            link.sprite.UpdatePos(Vector2.Zero);
            // update pos only takes new value w/ no option to increment
        }

        public void Exit()
        {
            // nothing for walking, new state should change sprites to idle/attacking/whatever
        }
    }
}
