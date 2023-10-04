
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
            switch (player.currentDirection)
            {
                case Direction.left:
                    player.stateMachine.ChangeState(new AttackingLeftLinkState());
                    player.stateMachine.Update();
                    break;
                case Direction.up:
                    player.stateMachine.ChangeState(new AttackingUpLinkState());
                    player.stateMachine.Update();
                    break;
                case Direction.right:
                    player.stateMachine.ChangeState(new AttackingRightLinkState());
                    player.stateMachine.Update();
                    break;
                case Direction.down:
                    player.stateMachine.ChangeState(new AttackingDownLinkState());
                    player.stateMachine.Update();
                    break;
            }
        }
    }
}
