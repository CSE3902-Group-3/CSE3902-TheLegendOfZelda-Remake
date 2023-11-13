using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectLeftCommand : ICommands
    {
        private Selector selector;

        public SelectLeftCommand(Selector selector)
        {
            this.selector = selector;
        }

        public void Execute()
        {
            selector.SelectLeft();
        }
    }
}
