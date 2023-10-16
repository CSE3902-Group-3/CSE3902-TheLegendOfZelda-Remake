using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AttackingLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public AttackingLeftLinkState()
        {
            this.game = Game1.getInstance();
            link = (Link)game.link;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            // Need to wait for PR#72 so this only executes once
            link.sprite = SpriteFactory.getInstance().CreateLinkWoodStabLeftSprite();
        }
        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.stateMachine.isTakingDamage;
        }

        public void Exit()
        {

        }

    }
}
