using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.TestUse
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
