using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    public class ItemScroll
    {
        private List<IItem> itemCollection;
        private int i = 0;

        public ItemScroll(Vector2 pos)
        {
            
            itemCollection = new List<IItem>()
            {
                new Arrow(pos),
                new Bomb(pos),
                new Boomerang(pos),
                new Bow(pos),
                new Candle(pos),
                new Clock(pos),
                new Compass(pos),
                new HeartContainer(pos),
                new Key(pos),
                new Map(pos),
                new Potion(pos),
                new Heart(pos),
                new Triforce(pos),
                new Fairy(pos),
                new Rupee(pos)
            };

            foreach (IItem item in itemCollection)
            {
                item.Remove();
            }

            itemCollection[i].Show();

        }

        public void nextItem()
        {
            itemCollection[i].Remove();

            if (i == itemCollection.Count-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }

            itemCollection[i].Show();
        }

        public void previousItem()
        {
            itemCollection[i].Remove();

            if (i == 0)
            {
                i = itemCollection.Count-1;
            }
            else
            {
                i--;
            }

            itemCollection[i].Show();
        }

    }
}