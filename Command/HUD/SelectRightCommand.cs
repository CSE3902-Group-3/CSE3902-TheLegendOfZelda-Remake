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

        public SelectRightCommand()
        {
            selector = Selector.GetInstance();
        }

        public void Execute()
        {
            selector.SelectRight();
        }
    }
}
