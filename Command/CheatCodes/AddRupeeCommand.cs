namespace LegendOfZelda
{
	public class AddRupeeCommand : ICommands
	{
		private AddRupee cheatCode;
		public AddRupeeCommand()
		{
			cheatCode = new AddRupee();
		}

		public void Execute()
		{
			cheatCode.Execute();
		}
	}
}

