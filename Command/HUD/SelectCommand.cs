using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SelectCommand : ICommands
    {
        private Selector selector;
        private InventoryHUD inventory;

        public SelectCommand()
        {
            selector = Selector.GetInstance();
            inventory = InventoryHUD.GetInstance();
        }

        public void Execute()
        {
            int index = selector.SelectCurrentItem();
            inventory.UpdateSelectedItem(index);
        }
    }
}
