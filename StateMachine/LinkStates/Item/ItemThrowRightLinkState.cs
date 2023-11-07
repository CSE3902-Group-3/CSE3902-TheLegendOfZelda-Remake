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

            // Throw item
            if (Inventory.getInstance().SecondaryItem is Bomb)
            {
                new BombProjectile(link.stateMachine.position + new Vector2(160, 0));
            }
            else if (Inventory.getInstance().SecondaryItem is Boomerang)
            {
                new BoomerangProjectile(link.stateMachine.position + new Vector2(160, 0), new Vector2(1, 0), link);
            }
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            link.stateMachine.canMove = true;
            ((AnimatedSprite)link.sprite).UnregisterSprite();
        }

    }
}
