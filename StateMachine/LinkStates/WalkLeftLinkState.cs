using LegendOfZelda.Interfaces;
using LegendOfZelda.Player;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.StateMachine.LinkStates
{
    public class WalkLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkLeftLinkState(Game1 game)
        {
            this.game = game;
            this.link = (Link)game.link;
            this.link.currentDirection = Link.Direction.Left;
        }

        public void Enter()
        {
            link.sprite = game.spriteFactory.CreateLinkWalkLeftSprite();
        }

        public void Execute()
        {
            Vector2 currPos = link.sprite.pos;
            currPos.X -= 1; // change this to velocity later
            link.sprite.UpdatePos(currPos);
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
            AnimatedSprite spriteAlias = (AnimatedSprite)this.link.sprite;
            spriteAlias.UnregisterSprite();
        }
    }
}
