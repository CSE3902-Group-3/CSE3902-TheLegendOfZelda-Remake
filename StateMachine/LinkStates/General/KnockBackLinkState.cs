using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class KnockBackLinkState : IState
    {
        private Link Link;

        private Vector2 targetPosition;  // The position Link should move to

        public KnockBackLinkState()
        {
            Link = GameState.Link;
        }

        public void Enter()
        {
            Link.StateMachine.canMove = false;
            Link.StateMachine.isKnockedBack = true;
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            switch (Link.StateMachine.currentDirection)
            {
                case Direction.up:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    break;
                case Direction.down:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    break;
                case Direction.left:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    break;
                case Direction.right:
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    break;
            }

            targetPosition = LinkUtilities.CalcKnockback(Link);
        }

        public void Execute()
        {
            if (Link.StateMachine.position != targetPosition)
            {
                Vector2 direction = Vector2.Normalize(targetPosition - Link.StateMachine.position);

                if (Vector2.Distance(Link.StateMachine.position, targetPosition) <= Link.Velocity)
                {
                    // If Link is very close to the target, snap to the target
                    LinkUtilities.UpdatePositions(Link, targetPosition);
                }
                else
                {
                    // Move Link towards the target position
                    LinkUtilities.UpdatePositions(Link, Link.StateMachine.position + (direction * Link.Velocity));
                }
            }

            if (Link.StateMachine.position == targetPosition)
            {
                // Only change the state to IdleLinkState when the target position is reached
                Link.StateMachine.ChangeState(new IdleLinkState());
            }
        }


        public void Exit()
        {
            Link.StateMachine.isKnockedBack = false;
        }
    }
}
