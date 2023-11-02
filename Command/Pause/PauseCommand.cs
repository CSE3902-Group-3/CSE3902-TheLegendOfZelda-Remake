using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
	public class PauseCommand : ICommands
	{
		private PauseManager pauseHandler;

		public PauseCommand(PauseManager pauseManager)
		{
			pauseHandler = pauseManager;
		}

		public void Execute()
		{
			pauseHandler.Pause();
		}
	}
}

