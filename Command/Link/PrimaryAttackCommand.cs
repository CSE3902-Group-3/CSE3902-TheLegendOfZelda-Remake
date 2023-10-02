
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
                    player.stateMachine.ChangeState(new AttackingLeftLinkState(Game1.instance));
                    break;
                case Direction.up:
                    player.stateMachine.ChangeState(new AttackingUpLinkState(Game1.instance));
                    break;
                case Direction.right:
                    player.stateMachine.ChangeState(new AttackingRightLinkState(Game1.instance));
                    break;
                case Direction.down:
                    player.stateMachine.ChangeState(new AttackingDownLinkState(Game1.instance));
                    break;
            }
        }
    }
}
