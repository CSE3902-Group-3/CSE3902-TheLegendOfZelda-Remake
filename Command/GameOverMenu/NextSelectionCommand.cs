namespace LegendOfZelda
{
	public class NextSelectionCommand : ICommands
	{
        private GameOverMenuSelector selector;

        public NextSelectionCommand()
        {
            selector = GameOverState.selector;
        }

        public void Execute()
        {
            selector.nextOption();
        }
    }
}

