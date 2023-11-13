using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectCommand : ICommands
    {
        private Selector selector;

        public SelectCommand(Selector selector)
        {
            this.selector = selector;
        }

        public void Execute()
        {
            selector.SelectCurrentItem();
        }
    }
}
