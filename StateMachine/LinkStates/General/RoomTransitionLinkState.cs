using Microsoft.Xna.Framework;
namespace LegendOfZelda
{
    public class RoomTransitionLinkState : IState
    {
        private Link Link;

        private Vector2 targetPosition;

        public RoomTransitionLinkState()
        {
            Link = GameState.Link;

            targetPosition = Link.StateMachine.position;
        }

        public void Enter()
        {
            Link.StateMachine.canMove = false;

            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            switch (Link.StateMachine.currentDirection)
            {
                case Direction.up:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    targetPosition += new Vector2(0, -196);
                    break;
                case Direction.down:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    targetPosition += new Vector2(0, 196);
                    break;
                case Direction.left:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    targetPosition += new Vector2(-196, 0);

                    break;
                case Direction.right:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    targetPosition += new Vector2(196, 0);
                    break;
            }
            Link.Sprite.paused = true;

            LinkUtilities.UpdatePositions(Link, targetPosition);
        }

        public void Execute()
        {

        }


        public void Exit()
        {
            Link.StateMachine.canMove = true;
            Link.Sprite.paused = false;
            Link.Velocity = 5;
        }
    }
}
