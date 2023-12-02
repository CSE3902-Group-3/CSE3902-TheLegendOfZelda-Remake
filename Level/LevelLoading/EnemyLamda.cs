using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyLamda
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
        // Refer to Level/Levels/LevelWritingInstructions.txt for the dictionary
        static void Aquamentus(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Aquamentus(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Bat(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Bat(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void BladeTrap(Room room, MapElement mapElement)
        {
            IEnemy enemy = new SpikeTrap(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Dodongo(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Dodongo(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void GelSmall(Room room, MapElement mapElement)
        {
            IEnemy enemy = new GelSmall(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Goriya(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Goriya(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Rope(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Rope(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Skeleton(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Skeleton(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void WallMaster(Room room, MapElement mapElement)
        {
            IEnemy enemy = new WallMaster(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void Wizard(Room room, MapElement mapElement)
        {
            IEnemy enemy = new Wizard(LevelUtilities.CalculateWizardCenterPosition(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
        static void ZolBig(Room room, MapElement mapElement)
        {
            IEnemy enemy = new ZolBig(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            LevelManager.CurrentLevelRoom.AddEnemy(enemy);
        }
    }
}
