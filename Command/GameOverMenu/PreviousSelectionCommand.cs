namespace LegendOfZelda
{
	public class PreviousSelectionCommand : ICommands
	{
		private GameOverMenuSelector selector;

		public PreviousSelectionCommand()
		{
			selector = new GameOverMenuSelector();
		}

		public void Execute()
		{
			/* This command is not needed for now */
			//selector.previousOption();
		}
	}
}

