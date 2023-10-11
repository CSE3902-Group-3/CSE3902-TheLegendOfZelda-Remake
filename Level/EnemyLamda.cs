using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class EnemyLamda
    {
        public delegate void Lamda(MapElement mapElement);
        public Lamda[] EnemyFunctionArray { get; }
        private static EnemyLamda Instance;
        private static int Scale = Level.Scale;
        /**
         * Enemy Lamda Function Dictionary
         * 
         * Arrow, 0
         */
        private EnemyLamda()
        {
            EnemyFunctionArray = new Lamda[]
            {
                Arrow,
            };
        }
        public static EnemyLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EnemyLamda();
            return Instance;
        }
        static void Arrow(MapElement mapElement)
        {
            IItem item = new Arrow(new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            item.Show();
        }
    }
}
