namespace LegendOfZelda
{
	public class ExecuteSelectionCommand : ICommands
	{
		private GameOverMenuSelector selector;

		public ExecuteSelectionCommand()
		{
			selector = GameState.Selector;
		}

		public void Execute()
		{
			selector.ExecuteSelection();
		}
	}
}

