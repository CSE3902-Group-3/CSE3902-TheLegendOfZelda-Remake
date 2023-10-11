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
        private static int Scale = Level.Scale;
        /**
         * Item Lamda Function Dictionary
         * 
         * Arrow, 0
         */
        private ItemLamda()
        {
            ItemFunctionArray = new Lamda[]
            {
                Arrow,
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
            IItem item = new Arrow(new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            item.Show();
        }
    }
}
