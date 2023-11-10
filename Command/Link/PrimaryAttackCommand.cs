
namespace LegendOfZelda
{
    public class PrimaryAttackCommand : ICommands
    {

        private Link player;

        public PrimaryAttackCommand(Link link)
        {
            player = link;

        }

        public void Execute()
        {
            switch (player.StateMachine.currentDirection)
            {
                case Direction.left:
                    player.StateMachine.ChangeState(new AttackingLeftLinkState());
                    break;
                case Direction.up:
                    player.StateMachine.ChangeState(new AttackingUpLinkState());
                    break;
                case Direction.right:
                    player.StateMachine.ChangeState(new AttackingRightLinkState());
                    break;
                case Direction.down:
                    player.StateMachine.ChangeState(new AttackingDownLinkState());
                    break;
            }
        }
    }
}
