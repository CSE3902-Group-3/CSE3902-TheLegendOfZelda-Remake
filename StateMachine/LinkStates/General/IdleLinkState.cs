namespace LegendOfZelda
{
    public class IdleLinkState : IState
    {
        private Link Link;

        // can pause animation in any direction, no need for separate states
        public IdleLinkState()
        {
            Link = GameState.Link;
        }

        public void Enter()
        {
            Link.StateMachine.canMove = true;
            // if we were not just walking, change sprite
            if (Link.StateMachine.PrevState.GetType() != typeof(WalkDownLinkState) &&
                Link.StateMachine.PrevState.GetType() != typeof(WalkUpLinkState) &&
                Link.StateMachine.PrevState.GetType() != typeof(WalkLeftLinkState) &&
                Link.StateMachine.PrevState.GetType() != typeof(WalkRightLinkState))
            {
                ((AnimatedSprite)Link.Sprite).UnregisterSprite();
                switch (Link.StateMachine.currentDirection)
                {
                    case Direction.left:
                        Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                        break;
                    case Direction.up:
                        Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                        break;
                    case Direction.right:
                        Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                        break;
                    case Direction.down:
                        Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                        break;
                }
            }
            // cast then pause animation of sprite
            ((AnimatedSprite)Link.Sprite).paused = true;
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            // cast then pause animation of sprite
            ((AnimatedSprite)Link.Sprite).paused = false;
        }
    }
}
