using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkDownLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkDownLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
            link.currentDirection = Link.Direction.Down;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkWalkDownSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.Y += 1; // change this to velocity later
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
