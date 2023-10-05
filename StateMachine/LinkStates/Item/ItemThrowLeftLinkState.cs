﻿using LegendOfZelda;

namespace LegendOfZelda
{
    public class ItemThrowLeftLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowLeftLinkState()
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
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowLeftSprite();
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
