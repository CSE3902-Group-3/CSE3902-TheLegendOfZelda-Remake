using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
	public class Inventory
	{
        private Dictionary<AnimatedSprite, int> inventory = new Dictionary<AnimatedSprite, int>();

        public void AddItem(AnimatedSprite item)
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

        public void RemoveItem(AnimatedSprite item)
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

        public int GetQuantity(AnimatedSprite item)
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

