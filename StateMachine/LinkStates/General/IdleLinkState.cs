﻿using LegendOfZelda;
using System.Runtime.CompilerServices;

namespace LegendOfZelda
{
    //Modified last minute by Michael to meet functionality deadline. Original author still needs to come back and finish
    public class IdleLinkState : IState
    {
        private Game1 game;
        private Link link;

        // can pause animation in any direction, no need for separate states
        public IdleLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
        }

        public void Enter()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.paused = true;
        }

        public void Execute()
        {
            // do nothing in idle state
        }

        public void Exit()
        {
            // cast then pause animation of sprite
            AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
            spriteAlias.paused = false;
        }
    }
}
