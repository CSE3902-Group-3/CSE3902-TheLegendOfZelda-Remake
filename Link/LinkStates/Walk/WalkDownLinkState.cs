using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkDownLinkState : IState
    {
        private Link Link;

        public WalkDownLinkState()
        {
            Link = GameState.Link;
            Link.StateMachine.prevDirection = Link.StateMachine.currentDirection;
            Link.StateMachine.currentDirection = Direction.down;
        }

        public void Enter()
        {
            Link.StateMachine.isWalking = true;
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
        }

        public void Execute()
        {
            if (Link.StateMachine.canMove)
            {
                Vector2 currPos = Link.Sprite.pos;
                currPos.Y += Link.Velocity;
                currPos.X += LinkUtilities.SnapToGrid((int)currPos.X);

                LinkUtilities.UpdatePositions(Link, currPos);
            }
        }

        public void Exit()
        {
            Link.StateMachine.isWalking = false;
        }
    }
}
