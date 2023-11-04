using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class RoomTransitionLinkState : IState
    {
        private Game1 game;
        private Link link;

        private Vector2 targetPosition;

        public RoomTransitionLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;

            targetPosition = link.stateMachine.position;
        }

        public void Enter()
        {
            link.stateMachine.canMove = false;
            link.collider.Active = false;

            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            switch (link.stateMachine.currentDirection)
            {
                case Direction.up:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    targetPosition += new Vector2(0, -194);
                    break;
                case Direction.down:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    targetPosition += new Vector2(0, 194);
                    break;
                case Direction.left:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    targetPosition += new Vector2(-194, 0);

                    break;
                case Direction.right:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    targetPosition += new Vector2(194, 0);
                    break;
            }
        }

        public void Execute()
        {
            if (link.stateMachine.position != targetPosition)
            {
                Vector2 direction = Vector2.Normalize(targetPosition - link.stateMachine.position);

                if (Vector2.Distance(link.stateMachine.position, targetPosition) <= link.velocity)
                {
                    // If Link is very close to the target, snap to the target
                    LinkUtilities.UpdatePositions(link, targetPosition);
                }
                else
                {
                    // Move Link towards the target position
                    LinkUtilities.UpdatePositions(link, link.stateMachine.position + (direction * link.velocity));
                }
            }

            if (link.stateMachine.position == targetPosition)
            {
                // Only change the state to IdleLinkState when the target position is reached
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }


        public void Exit()
        {
            link.stateMachine.canMove = true;
            link.collider.Active = true;
        }
    }
}
