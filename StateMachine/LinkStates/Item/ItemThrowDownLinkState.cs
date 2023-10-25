﻿using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;

using System.Diagnostics;

namespace LegendOfZelda
{
    public class ItemThrowDownLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowDownLinkState()
        {
            this.game = Game1.getInstance();
            this.link = (Link)game.link;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.stateMachine.canMove = false;
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowDownSprite();

            link.stateMachine.currentItem = new Bomb(link.stateMachine.position + new Vector2(30, 150));
            link.stateMachine.currentItem.Show();
        }

        public void Execute()
        {
            if (((AnimatedSprite)link.sprite).complete)
            {
                link.stateMachine.ChangeState(new IdleLinkState());
            }
        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
            ((AnimatedSprite)link.sprite).UnregisterSprite();
            // this should be done in the Item class I think? link shouldn't be responsible for this
            link.stateMachine.currentItem.Remove();
            link.stateMachine.currentItem = null;
        }

    }
}
