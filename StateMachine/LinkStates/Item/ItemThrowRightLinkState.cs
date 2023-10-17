using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowRightLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowRightLinkState()
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
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowRightSprite();

            link.stateMachine.currentItem = new Bomb(link.stateMachine.position + new Vector2(160, 0));
            link.stateMachine.currentItem.Show();
        }

        public void Execute()
        {
            ((AnimatedSprite)link.sprite).flashing = link.stateMachine.isTakingDamage;
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
