namespace LegendOfZelda
{
    public class EventLamda
    {
        public delegate void Lamda(Room room, LevelEvent levelEvent);
        public Lamda[] EventFunctionArray { get; }
        private static EventLamda Instance;
        private EventLamda()
        {
            EventFunctionArray = new Lamda[]
            {
                AllEnemiesDeadKeyDrop,
                AllEnemiesDeadBoomerangDrop
            };
        }
        public static EventLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EventLamda();
            return Instance;
        }
        public static void AllEnemiesDeadKeyDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadKeyDropEvent(room.RoomNumber, LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
        public static void AllEnemiesDeadBoomerangDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadBoomerangDropEvent(room.RoomNumber, LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
    }
}
