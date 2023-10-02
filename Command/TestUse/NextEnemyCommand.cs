
namespace LegendOfZelda
{
    public class NextEnemyCommand : ICommands
    {
        EnemyCycler enemyCycler;

        public NextEnemyCommand(EnemyCycler enemyCycler)
        {
            this.enemyCycler = enemyCycler;
        }

        public void Execute()
        {
            enemyCycler.CycleForward();
        }
    }
}
