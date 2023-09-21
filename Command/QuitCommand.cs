using LegendOfZelda.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    public class QuitCommand : ICommands
    {
        private Game1 game;

        public QuitCommand(Game1 game) 
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
    
    
}
