using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class WinningCommand : ICommands
    {
        WinningScreenManager winManager;

        public WinningCommand()
        {
            winManager = new WinningScreenManager();
        }

        public void Execute()
        {
            winManager.ActivateWinningScreen();
        }
    }
}
