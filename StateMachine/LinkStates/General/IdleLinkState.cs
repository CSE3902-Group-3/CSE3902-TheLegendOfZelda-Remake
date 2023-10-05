using LegendOfZelda;
using System.Runtime.CompilerServices;

namespace LegendOfZelda
{
    //Modified last minute by Michael to meet functionality deadline. Original author still needs to come back and finish
    public class IdleLinkState : IState
    {
        private Game1 game;
        private Link link;

        // can pause animation in any direction, no need for separate states
        public IdleLinkState()
        {
            this.game = Game1.getInstance();
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
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.paused = false;
        }
    }
}
