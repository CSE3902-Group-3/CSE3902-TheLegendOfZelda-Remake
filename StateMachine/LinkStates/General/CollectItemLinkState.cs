using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class CollectItemLinkState : IState
    {
        private Game1 game;
        private Link link;

        private IItem item;

        public CollectItemLinkState(IItem item)
        {
            this.game = Game1.getInstance();
            this.link = (Link)game.link;
            this.item = item;
        }

        public void Enter()
        {
            if (link.sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)link.sprite).UnregisterSprite();
            }
            link.stateMachine.canMove = false;
            link.sprite = SpriteFactory.getInstance().CreateLinkGetItemSprite();
        }

        public void Execute()
        {
            item.Use((link.stateMachine.position - new Vector2(-5, 60)));

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
            item.Remove();        
        }
    }
}
