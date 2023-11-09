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
            link = GameState.Link;
            link.StateMachine.prevDirection = link.StateMachine.currentDirection;
            link.StateMachine.currentDirection = Direction.up;
        }

        public void Enter()
        {
            link.StateMachine.isWalking = true;
            if (link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.Sprite).UnregisterSprite();
            }
            link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
        }

        public void Execute()
        {
            if (link.StateMachine.canMove)
            {
                Vector2 currPos = link.Sprite.pos;
                currPos.Y -= link.Velocity;
                currPos.X += LinkUtilities.SnapToGrid((int)currPos.X);
                LinkUtilities.UpdatePositions(link, currPos);
            }
        }

        public void Exit()
        {
            link.StateMachine.isWalking = false;
        }
    }
}
