﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
	public class Inventory
	{
        private Dictionary<IItem, int> inventory;

        // HUD should use this
        private IItem _secondaryItem;

        public IItem SecondaryItem
        {
            get { return _secondaryItem; }
            set
            {
                if (GetQuantity(value) > 0)
                {
                    _secondaryItem = value;
                }
            }
        }


        private static Inventory instance;

        public static Inventory getInstance()
        {
            if (instance == null)
                instance = new Inventory();

            return instance;
        }

        private Inventory()
        {
            /* All items in inventory will have a position of (0, 0),
             * their position can be changed when being used.
             */

            inventory = new Dictionary<IItem, int>();
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
            //return true;
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

