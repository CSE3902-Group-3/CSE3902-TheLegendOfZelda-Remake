
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
