using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class ItemLamda
    {
        public delegate void Lamda(MapElement mapElement);
        public Lamda[] ItemFunctionArray { get; }
        private static ItemLamda Instance;
        /**
         * Item Lamda Function Dictionary
         * 
         * Arrow, 0
         * Bomb, 1
         * Boomerang, 2
         * Bow, 3
         * Candle, 4
         * Clock, 5
         * Compass, 6
         * Fairy, 7
         * Heart, 8
         * HeartContainer, 9
         * Key, 10
         * Map, 11
         * Potion, 12
         * Rupee, 13
         * Triforce, 14
         * 
         */
        private ItemLamda()
        {
            ItemFunctionArray = new Lamda[]
            {
                Arrow,
                Bomb,
                Boomerang,
                Bow,
                Candle,
                Clock,
                Compass,
                Fairy,
                Heart,
                HeartContainer,
                Key,
                Map,
                Potion,
                Rupee,
                Triforce,
            };
        }
        public static ItemLamda GetInstance()
        {
            if (Instance == null)
                Instance = new ItemLamda();
            return Instance;
        }
        static void Arrow(MapElement mapElement)
        {
            IItem item = new Arrow(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        },
        static void Bomb(MapElement mapElement)
        {
            IItem item = new Bomb(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Boomerang(MapElement mapElement)
        {
            IItem item = new Boomerang(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Bow(MapElement mapElement)
        {
            IItem item = new Bow(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Candle(MapElement mapElement)
        {
            IItem item = new Candle(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Clock(MapElement mapElement)
        {
            IItem item = new Clock(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Compass(MapElement mapElement)
        {
            IItem item = new Compass(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Fairy(MapElement mapElement)
        {
            IItem item = new Fairy(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Heart(MapElement mapElement)
        {
            IItem item = new Heart(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void HeartContainer(MapElement mapElement)
        {
            IItem item = new HeartContainer(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Key(MapElement mapElement)
        {
            IItem item = new Key(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Map(MapElement mapElement)
        {
            IItem item = new Map(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Potion(MapElement mapElement)
        {
            IItem item = new Potion(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Rupee(MapElement mapElement)
        {
            IItem item = new Rupee(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
        static void Triforce(MapElement mapElement)
        {
            IItem item = new Triforce(new Vector2(mapElement.XLocation, mapElement.YLocation));
            item.Show();
        }
    }
}
