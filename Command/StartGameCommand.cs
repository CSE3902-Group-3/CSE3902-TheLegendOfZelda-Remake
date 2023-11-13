using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class StartGameCommand : ICommands
    {

        public StartGameCommand()
        {

        }

        public void Execute()
        {
            GameState.GetInstance().SwitchState(new NormalState());
        }
    }
}
