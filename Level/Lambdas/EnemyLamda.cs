using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class EnemyLamda
    {
        public delegate void Lamda(Room room, MapElement mapElement);
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
                Wizard,
                ZolBig
            };
        }
        public static EnemyLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EnemyLamda();
            return Instance;
        }
        static void Aquamentus(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Aquamentus(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Bat(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Bat(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void BladeTrap(Room room, MapElement mapElement)
        {
            IEnemy enemy = new BladeTrap(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Dodongo(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Dodongo(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void GelSmall(Room room, MapElement mapElement)
        {
            IEnemy enemy = new GelSmall(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Goriya(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Goriya(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Rope(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Rope(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Skeleton(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Skeleton(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void WallMaster(Room room, MapElement mapElement)
        {
            IEnemy enemy = new WallMaster(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void Wizard(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Wizard(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
        static void ZolBig(Room room, MapElement mapElement)
        {
            IEnemy enemy = new ZolBig(new Vector2(room.RoomXLocation + mapElement.XLocation, room.RoomYLocation+ mapElement.YLocation));
            LevelMaster.EnemiesList[LevelMaster.CurrentRoom].Add(enemy);
        }
    }
}
