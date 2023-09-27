﻿using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AttackingRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public AttackingRightLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
        }

        public void Enter()
        {
            // Need to wait for PR#72 so this only executes once
            link.sprite = game.spriteFactory.CreateLinkWoodStabRightSprite();
        }
        public void Execute()
        {
            // do nothing (for now)
        }

        public void Exit()
        {
            // cast then unregister sprite drawing
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.UnregisterSprite();
        }

    }
}
