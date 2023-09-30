﻿
namespace LegendOfZelda
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
