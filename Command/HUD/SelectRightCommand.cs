using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectRightCommand : ICommands
    {
        private Selector selector;

        public SelectRightCommand(Selector selector)
        {
            this.selector = selector;
        }

        public void Execute()
        {
            selector.SelectRight();
        }
    }
}
