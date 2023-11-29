namespace LegendOfZelda
{
	public class KillEnemiesCommand : ICommands
	{
		private KillAllEnemies cheatCode;
		public KillEnemiesCommand()
		{
			cheatCode = new KillAllEnemies();
		}

		public void Execute()
		{
			cheatCode.Execute();
		}
	}
}

