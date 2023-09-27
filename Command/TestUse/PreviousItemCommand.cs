﻿using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class PreviousItemCommand : ICommands
    {
        ItemScroll itemCycler;
        public PreviousItemCommand(ItemScroll itemCycler)
        {
            this.itemCycler = itemCycler;
        }
        public void Execute()
        {
            itemCycler.previousItem();
        }
    }
}
