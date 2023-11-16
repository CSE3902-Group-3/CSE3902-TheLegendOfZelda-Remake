using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LevelUtilities
    {
        public static int RoomWidth = 1024;
        public static int RoomHeight = 704;
        Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
        
        public Vector2 CalculateElementPositionWithOffset(Room room, MapElement mapElement)
        {

        }
        public Vector2 CalculateElementPositionWithNoOffset(Room room, MapElement mapElement)
        {

        }
    }
}
