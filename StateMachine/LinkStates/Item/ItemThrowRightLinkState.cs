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
            Link.StateMachine.canMove = false;
            Link.Sprite = SpriteFactory.getInstance().CreateLinkThrowRightSprite();
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
