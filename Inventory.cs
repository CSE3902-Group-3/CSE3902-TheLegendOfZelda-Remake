using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
	public class Inventory
	{
        private Dictionary<IItem, int> inventory = new Dictionary<IItem, int>();

        public void AddItem(IItem item)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item]++;
            }
            else
            {
                inventory[item] = 1;
            }
        }

        public void RemoveItem(IItem item)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item]--;

            }
            else if (inventory[item] <= 0)
            {
                inventory.Remove(item);
            }
        }

        public int GetQuantity(IItem item)
        {
            int itemAmount = 0;
            if (inventory.ContainsKey(item))
            {
                itemAmount = inventory[item];
            }

            return itemAmount;
        }
    }
}

