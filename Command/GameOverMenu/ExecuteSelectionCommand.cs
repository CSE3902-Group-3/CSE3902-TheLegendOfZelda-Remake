namespace LegendOfZelda
{
	public class ExecuteSelectionCommand : ICommands
	{
		private GameOverMenuSelector selector;

		public ExecuteSelectionCommand()
		{
			selector = GameOverState.selector;
		}

		public void Execute()
		{
			selector.ExecuteSelection();
		}
	}
}

