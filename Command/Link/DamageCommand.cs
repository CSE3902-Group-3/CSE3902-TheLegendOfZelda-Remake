
namespace LegendOfZelda
{
    public class DamageCommand : ICommands
    {

        private IPlayer player;

        public DamageCommand(IPlayer link)
        {
            player = link;

        }

        public void Execute()
        {
            player.stateMachine.ApplySuperState(new HurtLinkState(Game1.instance));
        }
    }
}
