using LegendOfZelda;
using Microsoft.Xna.Framework;

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
            link.stateMachine.canMove = false;
            link.sprite = SpriteFactory.getInstance().CreateLinkThrowLeftSprite();

            link.stateMachine.currentItem = new Bomb(link.stateMachine.position - new Vector2(90, 0));
            //Added in so I can test bomb usage
            new BombProjectile(link.stateMachine.position - new Vector2(90, 0));
            link.stateMachine.currentItem.Show();
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
            ((AnimatedSprite)link.sprite).UnregisterSprite();
            link.stateMachine.currentItem = null;
        }

    }
}
