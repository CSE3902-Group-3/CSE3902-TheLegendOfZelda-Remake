using LegendOfZelda;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ItemThrowUpLinkState : IState
    {
        private Game1 game;
        private Link link;

        public ItemThrowUpLinkState()
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
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowUpSprite();

            link.stateMachine.currentItem = new Bomb(link.stateMachine.position - new Vector2(-30, 150));
            //Added in so I can test bomb usage
            new BombProjectile(link.stateMachine.position - new Vector2(-30, 150));
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
            link.stateMachine.currentItem = null;
        }

    }
}
