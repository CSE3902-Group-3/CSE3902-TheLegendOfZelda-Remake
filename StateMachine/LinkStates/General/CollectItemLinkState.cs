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
        private Link Link;

        private IItem Item;

        public CollectItemLinkState(IItem item)
        {
            this.Link = GameState.Link;
            this.Item = item;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            Link.StateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkGetItemSprite();
        }

        public void Execute()
        {
            Item.Use((Link.StateMachine.position - new Vector2(-4, 60)));

            if (((AnimatedSprite)Link.Sprite).complete)
            {
                Link.StateMachine.ChangeState(new IdleLinkState());
                Item.Remove();
            }
            Item.Remove();
        }

        public void Exit()
        {
            Link.StateMachine.canMove = true;
            ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            // this should be done in the Item class I think? link shouldn't be responsible for this
            Item.Remove();        
        }
    }
}
