using System;
using System.Collections.Generic;
using System.Threading;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class ItemScroll
    {
        private List<IItem> itemCollection;

        public ItemScroll()
        {

            itemCollection = new List<IItem>
            {
                new Arrow(), new Bomb(), new Boomerang(), new Bow(), new Candle(), new Clock(), new Compass(), new HeartContainer(), new Key(), new Map(), new Potion(), new Heart(), new Triforce(), new Fairy(), new Rupee()
            };
        }

    }
}