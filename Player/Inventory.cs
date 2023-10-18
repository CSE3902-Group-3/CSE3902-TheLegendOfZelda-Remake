using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
	public class Inventory
	{
        private Dictionary<IItem, int> inventory;

        public Inventory()
        {
            /* All items in inventory will have a position of (0, 0),
             * their position can be changed when being used.
             */

            /* Amount of rupee will always be displayed on top of screen 
             * so initialize inventory with 0 rupee in dictionary
             */
            inventory = new Dictionary<IItem, int>
            {
                { new OneRupee(Vector2.Zero), 0 }
            };
        }

        public void AddItem(IItem item)
        {
            IItem inventoryItem = item.GenerateInventoryItem();
            if (inventory.ContainsKey(inventoryItem))
            {
                inventory[inventoryItem]++;
            }
            else
            {
                inventory.Add(inventoryItem, 1);
            }
            
        }

        // Return a boolean letting player know if item exists in inventory
        public bool RemoveItem(IItem item)
        {
            bool contain = false;
            IItem inventoryItem = item.GenerateInventoryItem();
            if (inventory.ContainsKey(inventoryItem))
            {
                inventory[inventoryItem]--;
                contain = true;
                if (inventory[inventoryItem] <= 0)
                {
                    inventory.Remove(inventoryItem);
                }
            }

            return contain;
        }

        /* Be sure to use this when adding rupee since there are two different kinds of rupee
         * and the way they are treated is a special case.
         */
        public void AddRupee(IItem rupee)
        {
            IItem inventoryRupee = rupee.GenerateInventoryItem();
            if (rupee is FiveRupee)
            {
                inventory[inventoryRupee] += 5;
            }
            if (rupee is OneRupee)
            {
                inventory[inventoryRupee]++;
            }
        }

        public bool SpendRupee(int price)
        {
            bool afford = true;
            IItem inventoryRupee = new OneRupee(Vector2.Zero);
            int inPocket = inventory[inventoryRupee];
            if (inPocket < price)
            {
                afford = false;
            }
            if (afford)
            {
                inventory[inventoryRupee] -= price;
            }

            return afford;
        }

        public int GetQuantity(IItem item)
        {
            IItem inventoryItem = item.GenerateInventoryItem();
            int itemAmount = 0;
            if (inventory.ContainsKey(inventoryItem))
            {
                itemAmount = inventory[inventoryItem];
            }

            return itemAmount;
        }
    }
}

