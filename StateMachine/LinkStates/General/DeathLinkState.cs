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
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;
        }

        public void Execute()
        {
            if (spins < 3)
            {
                counter++;

                if (counter < 10)
                {
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                }
                else if (counter < 20)
                {
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                }
                else if (counter < 30)
                {
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                }
                else if (counter < 40)
                {
                    Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                }
                else
                {
                    counter = 0;
                    spins++;
                }
            }
        }

        public void Exit()
        {

        }
    }
}
