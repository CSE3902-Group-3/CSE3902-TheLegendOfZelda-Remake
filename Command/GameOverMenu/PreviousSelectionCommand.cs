namespace LegendOfZelda
{
	public class PreviousSelectionCommand : ICommands
	{
		private GameOverMenuSelector selector;

		public PreviousSelectionCommand()
		{
			selector = GameState.Selector;
		}

		public void Execute()
		{
			/* This command is not needed for now */
			//selector.previousOption();
		}
	}
}

