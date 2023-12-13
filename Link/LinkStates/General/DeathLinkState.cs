using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class DeathLinkState : IState
    {
        private Link Link;
        private int counter = 0;
        private int spins = 0;

        public DeathLinkState()
        {
            this.Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                Link.Sprite.UnregisterSprite();
            }
            Link.Sprite = SpriteFactory.getInstance().CreateLinkDeathSprite();
            Link.StateMachine.canMove = false;
        }

        public void Execute()
        {
            counter++;

            if (counter % 10 == 0)
            {
                spins++;
            }

            if (spins > 16)
            {
                Link.Sprite.UnregisterSprite();
            }
        }

        public void Exit()
        {

        }
    }
}
