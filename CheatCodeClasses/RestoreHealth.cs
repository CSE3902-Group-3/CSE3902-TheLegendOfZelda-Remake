namespace LegendOfZelda
{
	public class RestoreHealth
	{
		private Link link;
		public RestoreHealth()
		{
			link = GameState.Link;
		}

		public void HealLink()
		{
			link.HP = link.GetMaxHP();
		}
	}
}

