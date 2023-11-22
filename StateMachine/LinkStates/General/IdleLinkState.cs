namespace LegendOfZelda
{
    public class IdleLinkState : IState
    {

        // can pause animation in any direction, no need for separate states
        public IdleLinkState(){}

        public void Enter()
        {
            GameState.Link.StateMachine.canMove = true;
            // if we were not just walking, change sprite
            if (GameState.Link.StateMachine.PrevState.GetType() != typeof(WalkDownLinkState) &&
                GameState.Link.StateMachine.PrevState.GetType() != typeof(WalkUpLinkState) &&
                GameState.Link.StateMachine.PrevState.GetType() != typeof(WalkLeftLinkState) &&
                GameState.Link.StateMachine.PrevState.GetType() != typeof(WalkRightLinkState))
            {
                ((AnimatedSprite)GameState.Link.Sprite).UnregisterSprite();
                switch (GameState.Link.StateMachine.currentDirection)
                {
                    case Direction.left:
                        GameState.Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkLeftSprite();
                        break;
                    case Direction.up:
                        GameState.Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkUpSprite();
                        break;
                    case Direction.right:
                        GameState.Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkRightSprite();
                        break;
                    case Direction.down:
                        GameState.Link.Sprite = SpriteFactory.getInstance().CreateLinkWalkDownSprite();
                        break;
                }
            }
            // cast then pause animation of sprite
            ((AnimatedSprite)GameState.Link.Sprite).paused = true;
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            // cast then pause animation of sprite
            ((AnimatedSprite)GameState.Link.Sprite).paused = false;
        }
    }
}
