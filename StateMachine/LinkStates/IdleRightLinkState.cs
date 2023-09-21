using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using System.Runtime.CompilerServices;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class IdleRightLinkState : IState
    {
        private Game1 game;
        private IPlayer link;
        private ISprite sprite;

        public IdleRightLinkState(Game1 game, ISprite sprite)
        {
            this.game = game;
            this.link = game.link;
            // really really hacky solution to an initialization problem
            // basically, the sprite is null when the state is created (bc it is initied in the link constructor)
            // so we alias the sprite to the sprite passed in which is the sprite in the (currently nulL) link initialization
            // or maybe I just make a "Initial" state with this ugly fix in it, then we can avoid having one state with a different constructor
            // than the 
            this.sprite = sprite;
        }

        public void Enter()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)this.sprite;
            spriteAlias.paused = true;
        }

        public void Execute()
        {
            // do nothing in idle state
        }

        public void Exit()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)this.sprite;
            spriteAlias.paused = false;
        }
    }
}
