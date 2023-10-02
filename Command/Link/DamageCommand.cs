
namespace LegendOfZelda
{
    public class DamageCommand : ICommands
    {

        private IPlayer player;

        private bool active;

        public DamageCommand(IPlayer link)
        {
            player = link;

        }

        public void Execute()
        {
            if (active)
            {
                active = false;
                ((Link)player).TakeDamage();
            } else
            {
                active = true;
                ((Link)player).Heal();
            }
        }
    }
}
