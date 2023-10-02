
namespace LegendOfZelda
{
    public class PreviousEnemyCommand : ICommands
    {
        EnemyCycler enemyCycler;

        public PreviousEnemyCommand(EnemyCycler enemyCycler)
        {
            this.enemyCycler = enemyCycler;
        }

        public void Execute()
        {
            enemyCycler.CycleBackward();
        }
    }
}
