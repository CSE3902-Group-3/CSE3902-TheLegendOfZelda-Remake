namespace LegendOfZelda
{
	public class NextSelectionCommand : ICommands
	{
        private GameOverMenuSelector selector;

        public NextSelectionCommand()
        {
            selector = new GameOverMenuSelector();
        }

        public void Execute()
        {
            selector.nextOption();
        }
    }
}

