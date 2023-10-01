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
            link.currentDirection = Direction.down;

        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkWalkUpSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.Y -= link.velocity;
            link.sprite.UpdatePos(currPos);
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.UnregisterSprite();
        }
    }
}
