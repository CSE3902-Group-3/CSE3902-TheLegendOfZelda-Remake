using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
	public class AddRupee : ICheatCode
	{
		private Inventory inventory;

		public AddRupee()
		{
			inventory = GameState.Link.StateMachine.linkInventory;
		}

		public void Execute()
		{
			inventory.AddRupee(new FiveRupee(Vector2.Zero));
		}
	}
}

