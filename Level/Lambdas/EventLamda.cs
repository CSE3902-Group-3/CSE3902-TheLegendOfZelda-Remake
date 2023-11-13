using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EventLamda
    {
        public delegate void Lamda(Room room, LevelEvent levelEvent);
        public Lamda[] EventFunctionArray { get; }
        private static EventLamda Instance;
        private static int YMenuOffset = 320; // y offset for menu
        private static int WallThickness = 128; // x position starts at the edge of the wall
        private static int YOffset = YMenuOffset + WallThickness; // y position starts at top menu height + edge of the wall, i.e. 320 + 128
        private static int Scale = 64; // size of a block

        private EventLamda()
        {
            EventFunctionArray = new Lamda[]
            {
                AllEnemiesDeadKeyDrop
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
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * levelEvent.XLocation, room.RoomYLocation + YOffset + Scale * levelEvent.YLocation);
            new AllEnemiesDeadKeyDropEvent(room.RoomNumber, pos);
        }

    }
}
