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
            // if we were not just walking, change sprite
            if (link.stateMachine.PrevState.GetType() != typeof(WalkDownLinkState) &&
                link.stateMachine.PrevState.GetType() != typeof(WalkUpLinkState) &&
                link.stateMachine.PrevState.GetType() != typeof(WalkLeftLinkState) &&
                link.stateMachine.PrevState.GetType() != typeof(WalkRightLinkState))
            {
                ((AnimatedSprite)link.sprite).UnregisterSprite();
                switch (link.stateMachine.currentDirection)
                {
                    case Direction.left:
                        link.sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                        break;
                    case Direction.up:
                        link.sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                        break;
                    case Direction.right:
                        link.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                        break;
                    case Direction.down:
                        link.sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                        break;
                }
            }
            // cast then pause animation of sprite
            ((AnimatedSprite)link.sprite).paused = true;
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            // cast then pause animation of sprite
            ((AnimatedSprite)link.sprite).paused = false;
        }
    }
}
