namespace LegendOfZelda
{
	public class ExecuteSelectionCommand : ICommands
	{
		private GameOverMenuSelector selector;

		public ExecuteSelectionCommand()
		{
			selector = new GameOverMenuSelector();
		}

		public void Execute()
		{
			selector.ExecuteSelection();
		}
	}
}

