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
        private Game1 game;
        private Link link;

        private Vector2 targetPosition;  // The position Link should move to

        public KnockBackLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
        }

        public void Enter()
        {
            link.stateMachine.canMove = false;
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            switch (link.stateMachine.currentDirection)
            {
                case Direction.up:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    break;
                case Direction.down:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    break;
                case Direction.left:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    break;
                case Direction.right:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    break;
            }

            targetPosition = LinkUtilities.CalcKnockback(link);
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
            else
            {
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
        }
    }
}
