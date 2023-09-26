using LegendOfZelda.Environment;
using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.TestUse
{
    public class NextItemCommand : ICommands
    {
        ItemScroll itemCycler;
        public NextItemCommand(ItemScroll itemCycler)
        {
            this.itemCycler = itemCycler;
        }
        public void Execute()
        {
            itemCycler.nextItem();
        }
    }
}
