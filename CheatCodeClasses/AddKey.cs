using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AddKey : ICheatCode
    {
        private Inventory inventory;

        public AddKey()
        {
            inventory = GameState.Link.StateMachine.linkInventory;
        }

        public void Execute()
        {
            inventory.AddItem(new Key(Vector2.Zero));
        }
    }
}

