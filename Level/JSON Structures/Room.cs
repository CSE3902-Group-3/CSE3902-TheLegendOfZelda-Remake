using System.Collections.Generic;
namespace LegendOfZelda
{
    public class RoomList
    {
        public List<Room> Rooms { get; set; }
    }
    public class Room
    {
        public int RoomNumber { get; set; }
        public int RoomXLocation { get; set; }
        public int RoomYLocation { get; set; }
        public List<LevelEvent> Events { get; set; } = new List<LevelEvent>();
        public List<AdjacentRoom> AdjacentRooms { get; set; }
        public List<MapElement> MapElements { get; set; }
    }
    public class AdjacentRoom
    {
        public int RoomNumber { get; set; }
        public string Direction { get; set; }
    }
}
