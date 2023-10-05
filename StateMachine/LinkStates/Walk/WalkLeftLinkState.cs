using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkLeftLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
            link.currentDirection = Direction.left;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.X -= link.velocity;
            link.sprite.UpdatePos(currPos);

            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {

        }
    }
}
