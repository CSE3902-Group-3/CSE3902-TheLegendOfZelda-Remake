using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LinkInventory
    {
        private IItem[] items;

      

        public LinkInventory()
        {
            items = new IItem[2]; // link can only hold 2 items at a time; primary and secondary
        }

        public void AddItem(IItem item)
        {
            if (items.Length == 0)
                items[0] = item;
            else if (items.Length == 1 && items[0] != null)
                items[1] = item;
            else if (items.Length == 1 && items[1] != null)
                items[0] = item;
        }

        public void RemovePrimaryItem()
        {
            items[0] = null;
        }

        public void RemoveSecondaryItem()
        {
            items[1] = null;
        }

        public IItem GetPrimaryItem()
        {
            return items[0];
        }

        public IItem GetSecondaryItem() {
            return items[1];
        }
    }
}
