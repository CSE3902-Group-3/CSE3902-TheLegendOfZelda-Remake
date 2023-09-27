using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
