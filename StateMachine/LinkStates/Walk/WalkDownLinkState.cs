using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkDownLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkDownLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
            link.currentDirection = Direction.down;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
                spriteAlias.UnregisterSprite();
            }
            link.sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.Y += link.velocity;
            currPos.X += LinkUtilities.SnapToGrid((int)currPos.X);

            link.sprite.UpdatePos(currPos);

            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
        }
    }
}
