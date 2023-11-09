using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<AdjacentRoom> AdjacentRooms { get; set; }
        public List<MapElement> MapElements { get; set; }
    }
    public class AdjacentRoom
    {
        public int RoomNumber { get; set; }
        public string Direction { get; set; }
    }
}
