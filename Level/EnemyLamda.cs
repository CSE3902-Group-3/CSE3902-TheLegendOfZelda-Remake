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
        private EnemyLamda()
        {
            EnemyFunctionArray = new Lamda[]
            {
                Aquamentus,
                Bat,
                BladeTrap,
                Dodongo,
                GelSmall,
                Goriya,
                Rope,
                Skeleton,
                WallMaster,
                Wizard
            };
        }
        public static EnemyLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EnemyLamda();
            return Instance;
        }
        static void Aquamentus(MapElement mapElement)
        {
            IEnemy enemy = new Aquamentus(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Bat(MapElement mapElement)
        {
            IEnemy enemy = new Bat(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void BladeTrap(MapElement mapElement)
        {
            IEnemy enemy = new BladeTrap(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Dodongo(MapElement mapElement)
        {
            IEnemy enemy = new DodongoState(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void GelSmall(MapElement mapElement)
        {
            IEnemy enemy = new GelSmall(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Goriya(MapElement mapElement)
        {
            IEnemy enemy = new Goriya(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Rope(MapElement mapElement)
        {
            IEnemy enemy = new Rope(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Skeleton(MapElement mapElement)
        {
            IEnemy enemy = new Skeleton(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void WallMaster(MapElement mapElement)
        {
            IEnemy enemy = new WallMaster(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void Wizard(MapElement mapElement)
        {
            IEnemy enemy = new Wizard(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
        static void ZolBig(MapElement mapElement)
        {
            IEnemy enemy = new ZolBig(new Vector2(mapElement.XLocation, mapElement.YLocation));
            enemy.Spawn();
        }
    }
}
