using LegendOfZelda.Environment;
using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.TestUse
{
    public class NextBlockCommand : ICommands
    {
        BlockCycler blockCycler;
        public NextBlockCommand(BlockCycler blockCycler) {
            this.blockCycler = blockCycler;
        }
        public void Execute()
        {
            blockCycler.cycleForward();
        }
    }
}
