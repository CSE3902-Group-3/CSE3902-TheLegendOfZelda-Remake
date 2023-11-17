namespace LegendOfZelda
{
    public class ItemLamda
    {
        public delegate void Lamda(Room room, MapElement mapElement);
        public Lamda[] ItemFunctionArray { get; }
        private static ItemLamda Instance;
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
        static void Arrow(Room room, MapElement mapElement)
        {
            IItem item = new Arrow(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Bomb(Room room, MapElement mapElement)
        {
            IItem item = new Bomb(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Boomerang(Room room, MapElement mapElement)
        {
            IItem item = new Boomerang(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Bow(Room room, MapElement mapElement)
        {
            IItem item = new Bow(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Candle(Room room, MapElement mapElement)
        {
            IItem item = new Candle(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Clock(Room room, MapElement mapElement)
        {
            IItem item = new Clock(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Compass(Room room, MapElement mapElement)
        {
            IItem item = new Compass(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Fairy(Room room, MapElement mapElement)
        {
            IItem item = new Fairy(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Heart(Room room, MapElement mapElement)
        {
            IItem item = new Heart(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void HeartContainer(Room room, MapElement mapElement)
        {
            IItem item = new HeartContainer(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Key(Room room, MapElement mapElement)
        {
            IItem item = new Key(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Map(Room room, MapElement mapElement)
        {
            IItem item = new Map(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Potion(Room room, MapElement mapElement)
        {
            IItem item = new Potion(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Rupee(Room room, MapElement mapElement)
        {
            IItem item = new FiveRupee(LevelUtilities.CalculatePositionWallOffset(room, mapElement));
            item.Show();
        }
        static void Triforce(Room room, MapElement mapElement)
        {
            IItem item = new Triforce(LevelUtilities.CalculateTriforceCenterPosition(room, mapElement));
            item.Show();
        }
    }
}
