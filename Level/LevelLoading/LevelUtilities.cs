using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LevelUtilities
    {
        private static int Scale = SpriteFactory.getInstance().scale;
        public static int RoomWidth { get; } = Scale * 256;
        public static int RoomHeight { get; } = Scale * 176;
        public static int GridUnitSize { get; } = Scale * 16;
        public static int WallOffset { get; } = Scale * 32;
        public static int YMenuOffset { get; } = Scale * 48;
        public static Vector2 CalculatePositionWallOffset(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WallOffset + GridUnitSize * mapElement.XLocation, room.RoomYLocation * RoomHeight * -1 + WallOffset + YMenuOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculatePositionNoWallOffset(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WallOffset + GridUnitSize * mapElement.XLocation, room.RoomYLocation * RoomHeight * -1 + WallOffset + YMenuOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculateExteriorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1 + YMenuOffset);
        }
    }
}
