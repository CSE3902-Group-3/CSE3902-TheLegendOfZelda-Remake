using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkRightLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
            link.stateMachine.currentDirection = Direction.right;
        }

        public void Enter()
        {
            link.stateMachine.isWalking = true;
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
        }

        public void Execute()
        {
            if (link.stateMachine.canMove)
            {
                Vector2 currPos = link.sprite.pos;
                currPos.X += link.velocity;
                currPos.Y += LinkUtilities.SnapToGrid((int)currPos.Y);

                link.stateMachine.position = currPos;
                link.sprite.UpdatePos(currPos);
            }

            ((AnimatedSprite)link.sprite).flashing = link.stateMachine.isTakingDamage;
        }

        public void Exit()
        {
            link.stateMachine.isWalking = false;
        }
    }
}
