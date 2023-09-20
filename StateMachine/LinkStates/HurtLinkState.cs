using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class HurtLinkState : IState
    {
        private Game1 game { get; set; }

        // this is in game but this gives us quick access to it
        private Link link { get; set; }

        public HurtLinkState(Game1 game, Link link)
        {
            this.game = game;
            this.link = link;
        }

        public void Enter()
        {
            // change sprites to hurt link
        }

        public void Exit()
        {
            // remove hurt sprite effects
        }
    }
}
