using LegendOfZelda;

namespace LegendOfZelda
{
    public class InititalLinkState : IState
    {
        private ISprite sprite;

        public InititalLinkState(ISprite sprite)
        {
            // really really hacky solution to an initialization problem
            // basically, the sprite is null when the state is created (bc it is initied in the link constructor)
            // so we alias the sprite to the sprite passed in which is the sprite in the (currently nulL) link initialization
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

            spriteAlias.UnregisterSprite();
        }
    }
}
