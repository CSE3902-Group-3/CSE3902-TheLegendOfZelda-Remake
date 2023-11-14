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

        public SelectUpCommand()
        {
            selector = Selector.GetInstance();
        }

        public void Execute()
        {
            selector.SelectUp();
        }
    }
}
