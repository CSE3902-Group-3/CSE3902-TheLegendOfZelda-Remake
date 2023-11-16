using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LevelUtilities
    {
        public static int RoomWidth { get; } = 1024;
        public static int RoomHeight { get; } = 704;
        public static int GridUnitSize { get; } = SpriteFactory.getInstance().scale * 16;
        public static int YMenuOffset { get; } = 192;
        public static Vector2 CalculateElementPositionWithOffset(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WallThickness + GridUnitSize * mapElement.XLocation, room.RoomYLocation * RoomHeight * -1 + YOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculateElementPositionWithNoOffset(Room room, MapElement mapElement)
        {

        }
    }
}
