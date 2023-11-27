namespace LegendOfZelda
{
	public class RestoreHealthCommand : ICommands
	{
		private RestoreHealth cheatCode;
		public RestoreHealthCommand()
		{
			cheatCode = new RestoreHealth();
		}

		public void Execute()
		{
			cheatCode.Execute();
		}
	}
}

