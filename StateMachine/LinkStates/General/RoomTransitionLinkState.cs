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

            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            switch (link.stateMachine.currentDirection)
            {
                case Direction.up:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                    targetPosition += new Vector2(0, -196);
                    break;
                case Direction.down:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                    targetPosition += new Vector2(0, 196);
                    break;
                case Direction.left:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                    targetPosition += new Vector2(-196, 0);

                    break;
                case Direction.right:
                    link.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                    targetPosition += new Vector2(196, 0);
                    break;
            }

            LinkUtilities.UpdatePositions(link, targetPosition);
        }

        public void Execute()
        {

        }


        public void Exit()
        {
            link.stateMachine.canMove = true;
            link.velocity = 5;
        }
    }
}
