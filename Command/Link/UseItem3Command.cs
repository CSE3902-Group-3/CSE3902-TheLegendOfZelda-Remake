
namespace LegendOfZelda
{
    public class UseItem3Command : ICommands
    {
        private Link player;

        public UseItem3Command(Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            /*
            switch (player.stateMachine.currentDirection)
            {
                case Direction.left:
                    player.stateMachine.ChangeState(new ItemThrowLeftLinkState());
                    break;
                case Direction.up:
                    player.stateMachine.ChangeState(new ItemThrowUpLinkState());
                    break;
                case Direction.right:
                    player.stateMachine.ChangeState(new ItemThrowRightLinkState());
                    break;
                case Direction.down:
                    player.stateMachine.ChangeState(new ItemThrowDownLinkState());
                    break;
            }
            */
        }
    }
}
