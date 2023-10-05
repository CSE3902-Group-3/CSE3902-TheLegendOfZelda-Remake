using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkUpLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkUpLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
            link.currentDirection = Direction.up;

        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
                spriteAlias.UnregisterSprite();
            }
            link.sprite = game.spriteFactory.CreateLinkWalkUpSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.Y -= link.velocity;
            currPos.X += LinkUtilities.SnapToGrid((int)currPos.X);

            link.sprite.UpdatePos(currPos);

            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {

        }
    }
}
