namespace LegendOfZelda
{
	public class NextSelectionCommand : ICommands
	{
        private GameOverMenuSelector selector;

        public NextSelectionCommand()
        {
            selector = GameState.Selector;
        }

        public void Execute()
        {
            selector.nextOption();
        }
    }
}

