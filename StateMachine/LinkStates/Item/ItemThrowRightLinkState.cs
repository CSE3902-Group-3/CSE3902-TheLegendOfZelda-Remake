namespace LegendOfZelda
{
    public class ItemThrowRightLinkState : IState
    {
        private Link Link;

        public ItemThrowRightLinkState()
        {
            this.Link = GameState.Link;
        }

        public void Enter()
        {
            if (Link.Sprite != null)
            {
                // if there was a previous sprite, cast then unregister sprite
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
            }
            link.stateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowRightSprite();

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
            Link.StateMachine.canMove = true;
            ((AnimatedSprite)Link.Sprite).UnregisterSprite();
        }

    }
}
