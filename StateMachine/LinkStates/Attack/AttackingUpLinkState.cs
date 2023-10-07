﻿using LegendOfZelda;
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

        public AttackingUpLinkState()
        {
            this.game = Game1.getInstance();
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
            link.stateMachine.canMove = false;

            link.sprite = SpriteFactory.getInstance().CreateLinkWoodStabUpSprite();
        }
        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.isTakingDamage;

            if (((AnimatedSprite)link.sprite).complete)
            {
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
        }

    }
}
