using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class PreviousPalletCommand : ICommands
    {
        public void Execute()
        {
            ShaderHolder.CyclePalletteBackward();
        }
    }
}
