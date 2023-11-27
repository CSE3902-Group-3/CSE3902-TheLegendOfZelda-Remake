using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
	public class AddRupee
	{
		private Inventory inventory;

		public AddRupee()
		{
			inventory = GameState.Link.StateMachine.linkInventory;
		}

		public void AddRupeeToInventory()
		{
			inventory.AddRupee(new FiveRupee(Vector2.Zero));
		}
	}
}

