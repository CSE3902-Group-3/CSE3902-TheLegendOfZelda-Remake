﻿using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class WalkLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public WalkLeftLinkState(Game1 game)
        {
            this.game = game;
            link = (Link)game.link;
            link.currentDirection = Link.Direction.Left;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                AnimatedSprite spriteAlias = (AnimatedSprite)link.sprite;
                spriteAlias.UnregisterSprite();
            }
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

        }
    }
}
