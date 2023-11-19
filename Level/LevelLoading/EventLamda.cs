using LegendOfZelda.Level;

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
                AllEnemiesDeadBoomerangDrop,
                AllEnemiesDeadOpenEastDoor,
                PushBlockWestOpenWestDoor
            };
        }
        public static EventLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EventLamda();
            return Instance;
        }
        // There is no ordering to the events, they are just added as needed
        // Refer to Level/Levels/LevelWritingInstructions.txt for the dictionary
        public static void AllEnemiesDeadKeyDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadKeyDropEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
        public static void AllEnemiesDeadBoomerangDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadBoomerangDropEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
        public static void AllEnemiesDeadOpenEastDoor(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadOpenClosedEastDoorEvent(room);
        }
        public static void PushBlockWestOpenWestDoor(Room room, LevelEvent levelEvent)
        {
            new PushBlockWestOpenWestClosedDoorEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent), room);
        }
    }
}
