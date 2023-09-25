using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using System.Runtime.CompilerServices;

namespace LegendOfZelda.StateMachine.LinkStates.General
{
    public class IdleLinkState : IState
    {
        private Game1 game;
        private Link link;

        // can pause animation in any direction, no need for separate states
        public IdleLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
        }

        public void Enter()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.paused = true;
        }

        public void Execute()
        {
            // do nothing in idle state
        }

        public void Exit()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.paused = false;

            spriteAlias.UnregisterSprite();
        }
    }
}
