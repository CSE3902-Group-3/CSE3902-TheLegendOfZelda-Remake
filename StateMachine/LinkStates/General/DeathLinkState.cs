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
        private int spinBuffer = 0;
        private int totalSpins = 0;

        public DeathLinkState()
        {
            this.Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkDeathSprite();
        }

        public void Execute()
        {

        }

        public void Exit()
        {

        }
    }
}
