using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AttackingUpLinkState : IState
    {
        private Game1 game;
        private Link link;

        public AttackingUpLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
                spriteAlias.UnregisterSprite();
            }
            // Need to wait for PR#72 so this only executes once
            link.sprite = game.spriteFactory.CreateLinkWoodStabUpSprite();
        }
        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;
        }

        public void Exit()
        {

        }

    }
}
