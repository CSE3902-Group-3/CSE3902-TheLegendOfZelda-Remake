namespace LegendOfZelda
{
	public class RestoreHealth : ICheatCode
	{
		private Link link;
		public RestoreHealth()
		{
			link = GameState.Link;
		}

		public void Execute()
		{
			link.Heal(6.0f);
		}
	}
}

