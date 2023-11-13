using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectUpCommand : ICommands
    {
        private Selector selector;

        public SelectUpCommand(Selector selector)
        {
            this.selector = selector;
        }

        public void Execute()
        {
            selector.SelectUp();
        }
    }
}
