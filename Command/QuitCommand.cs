using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class QuitCommand : ICommands
    {
        private Game1 game;

        public QuitCommand() 
        {
            this.game = Game1.getInstance();
        }

        public void Execute()
        {
            game.Exit();
        }
    }
    
    
}
