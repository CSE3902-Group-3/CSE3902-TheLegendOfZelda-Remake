
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
                case Link.Direction.Left:
                    player.stateMachine.ChangeState(new AttackingLeftLinkState(Game1.instance));
                    break;
                case Link.Direction.Up:
                    player.stateMachine.ChangeState(new AttackingUpLinkState(Game1.instance));
                    break;
                case Link.Direction.Right:
                    player.stateMachine.ChangeState(new AttackingRightLinkState(Game1.instance));
                    break;
                case Link.Direction.Down:
                    player.stateMachine.ChangeState(new AttackingDownLinkState(Game1.instance));
                    break;
            }
        }
    }
}
