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
        private int i = 0;

        public ItemScroll()
        {

            itemCollection = new List<IItem>
            {
                new Arrow(Game1.instance),
                new Bomb(Game1.instance),
                new Boomerang(Game1.instance),
                new Bow(Game1.instance),
                new Candle(Game1.instance),
                new Clock(Game1.instance),
                new Compass(Game1.instance),
                new HeartContainer(Game1.instance),
                new Key(Game1.instance),
                new Map(Game1.instance),
                new Potion(Game1.instance),
                new Heart(Game1.instance),
                new Triforce(Game1.instance),
                new Fairy(Game1.instance),
                new Rupee(Game1.instance)
            };
        }

        /*Hard coded the number of elements in itemCollection since that will be all that are 
         * needed and this number is not likely to be changed later.
         * */
        public void nextItem()
        {
            if(i == 14)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }

        public void previousItem()
        {
            if(i == 0)
            {
                i = 14;
            }
            else
            {
                i--;
            }
        }

    }
}