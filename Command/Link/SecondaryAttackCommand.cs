
namespace LegendOfZelda
{
    public class SecondaryAttackCommand : ICommands
    {
        public SecondaryAttackCommand(){}

        public void Execute()
        {
            switch (GameState.Link.StateMachine.currentDirection)
            {
                case Direction.left:
                    GameState.Link.StateMachine.ChangeState(new AttackingLeftLinkState());
                    break;
                case Direction.up:
                    GameState.Link.StateMachine.ChangeState(new AttackingUpLinkState());
                    break;
                case Direction.right:
                    GameState.Link.StateMachine.ChangeState(new AttackingRightLinkState());
                    break;
                case Direction.down:
                    GameState.Link.StateMachine.ChangeState(new AttackingDownLinkState());
                    break;
            }
        }
    }
}
