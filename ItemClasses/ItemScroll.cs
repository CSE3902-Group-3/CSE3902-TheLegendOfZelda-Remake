using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
    public class ItemScroll
    {
        //private List<IItem> itemCollection;
        private int i = 0;
        private IItem item;
        private Vector2 pos;

        public ItemScroll(Vector2 pos)
        {
            /*
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
            */

            this.pos = pos;
            item = createItem(i);
            
        }

        /*Hard coded the number of elements in itemCollection since that will be all that are 
         * needed and this number is not likely to be changed later.
         * */
        public void nextItem()
        {
            item.Remove();

            if(i == 14)
            {
                i = 0;
            }
            else
            {
                i++;
            }

            item = createItem(i);
        }

        public void previousItem()
        {
            item.Remove();

            if(i == 0)
            {
                i = 14;
            }
            else
            {
                i--;
            }

            item = createItem(i);
        }

        private IItem createItem(int id)
        {
            switch(id)
            {
                case 0:
                    return new Arrow(Game1.instance, pos);
                case 1:
                    return new Bomb(Game1.instance, pos);
                case 2:
                    return new Boomerang(Game1.instance, pos);
                case 3:
                    return new Bow(Game1.instance, pos);
                case 4:
                    return new Candle(Game1.instance, pos);
                case 5:
                    return new Clock(Game1.instance, pos);
                case 6:
                    return new Compass(Game1.instance, pos);
                case 7:
                    return new HeartContainer(Game1.instance, pos);
                case 8:
                    return new Key(Game1.instance, pos);
                case 9:
                    return new Map(Game1.instance, pos);
                case 10:
                    return new Potion(Game1.instance, pos);
                case 11:
                    return new Heart(Game1.instance, pos);
                case 12:
                    return new Triforce(Game1.instance, pos);
                case 13:
                    return new Fairy(Game1.instance, pos);
                case 14:
                    return new Rupee(Game1.instance, pos);
                default:
                    return null;

            }
        }

    }
}