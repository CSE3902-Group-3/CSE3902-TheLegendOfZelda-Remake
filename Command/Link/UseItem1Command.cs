
namespace LegendOfZelda
{
    public class UseItem1Command : ICommands
    {
        private Link player;

        public UseItem1Command(Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            switch (player.StateMachine.currentDirection)
            {
                case Direction.left:
                    player.StateMachine.ChangeState(new ItemThrowLeftLinkState());
                    break;
                case Direction.up:
                    player.StateMachine.ChangeState(new ItemThrowUpLinkState());
                    break;
                case Direction.right:
                    player.StateMachine.ChangeState(new ItemThrowRightLinkState());
                    break;
                case Direction.down:
                    player.StateMachine.ChangeState(new ItemThrowDownLinkState());
                    break;
            }
        }
    }
}
