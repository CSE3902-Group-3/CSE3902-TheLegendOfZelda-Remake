using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectDownCommand : ICommands
    {
        private Selector selector;

        public SelectDownCommand()
        {
            selector = Selector.GetInstance();
        }

        public void Execute()
        {
            selector.SelectDown();
        }
    }
}
