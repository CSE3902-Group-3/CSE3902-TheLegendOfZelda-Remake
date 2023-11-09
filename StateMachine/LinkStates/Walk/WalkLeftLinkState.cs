using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkLeftLinkState : IState
    {
        private Link Link;

        public WalkLeftLinkState()
        {
            Link = GameState.Link;
            Link.StateMachine.prevDirection = Link.StateMachine.currentDirection;
            Link.StateMachine.currentDirection = Direction.left;
        }

        public void Enter()
        {
            Link.StateMachine.isWalking = true;
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
        }

        public void Execute()
        {
            if (Link.StateMachine.canMove)
            {
                Vector2 currPos = Link.Sprite.pos;
                currPos.X -= Link.Velocity;
                currPos.Y += LinkUtilities.SnapToGrid((int)currPos.Y);

                LinkUtilities.UpdatePositions(Link, currPos);
            }
        }

        public void Exit()
        {
            Link.StateMachine.isWalking = false;
        }
    }
}
