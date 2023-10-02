
namespace LegendOfZelda
{
    public class UseItemCommand : ICommands
    {
        private Link player;

        public UseItemCommand(Link player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseItem();
        }
    }
}
