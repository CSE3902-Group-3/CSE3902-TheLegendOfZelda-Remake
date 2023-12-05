using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AddBomb : ICheatCode
    {
        private Inventory inventory;

        public AddBomb()
        {
            inventory = GameState.Link.StateMachine.linkInventory;
        }

        public void Execute()
        {
            inventory.AddItem(new Bomb(Vector2.Zero));
        }
    }
}

