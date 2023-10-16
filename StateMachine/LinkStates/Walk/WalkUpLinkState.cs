using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkUpLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkUpLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
            link.stateMachine.prevDirection = link.stateMachine.currentDirection;
            link.stateMachine.currentDirection = Direction.up;
        }

        public void Enter()
        {
            link.stateMachine.isWalking = true;
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
        }

        public void Execute()
        {
            if (link.stateMachine.canMove)
            {
                Vector2 currPos = link.sprite.pos;
                currPos.Y -= link.velocity;
                currPos.X += LinkUtilities.SnapToGrid((int)currPos.X);
                LinkUtilities.UpdatePositions(link, currPos);
            }

            ((AnimatedSprite)link.sprite).flashing = link.stateMachine.isTakingDamage;
        }

        public void Exit()
        {
            link.stateMachine.isWalking = false;
        }
    }
}
