using Microsoft.Xna.Framework;
using static System.Formats.Asn1.AsnWriter;

namespace LegendOfZelda
{
    internal class LevelUtilities
    {
        public static int RoomWidth { get; private set; }
        public static int RoomHeight { get; private set; }
        public static int GridUnitSize { get; private set; }
        public static int WallOffset { get; private set; }
        public static int YMenuOffset { get; private set; }

        private static Vector2 NorthDoorPosition;
        private static Vector2 EastDoorPosition;
        private static Vector2 SouthDoorPosition;
        private static Vector2 WestDoorPosition;

        // Certain objects need to be centered inside the room
        private static int WizardXPosition;
        private static int TriforceXPosition;

        // Numbers are based on number of pixels from sprite sheet
        public static void SetLevelLoadingValues(int scale)
        {
            RoomWidth = scale * 256;
            RoomHeight = scale * 176;
            GridUnitSize = scale * 16;
            WallOffset = scale * 32;
            YMenuOffset = scale * 48;
            NorthDoorPosition = new Vector2(RoomWidth / 2 - GridUnitSize, YMenuOffset);
            EastDoorPosition = new Vector2(RoomWidth - WallOffset, RoomHeight / 2 - GridUnitSize + YMenuOffset);
            SouthDoorPosition = new Vector2(RoomWidth / 2 - GridUnitSize, YMenuOffset + RoomHeight - WallOffset);
            WestDoorPosition = new Vector2(0, RoomHeight / 2 - GridUnitSize + YMenuOffset);
            WizardXPosition = (RoomWidth - scale * 18) / 2;
            TriforceXPosition = (RoomWidth - scale * 12) / 2;
        }
        public static Vector2 CalculatePositionWallOffset(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WallOffset + GridUnitSize * mapElement.XLocation, room.RoomYLocation * RoomHeight * -1 + WallOffset + YMenuOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculatePositionWallOffset(Room room, LevelEvent levelEvent)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WallOffset + GridUnitSize * levelEvent.XLocation, room.RoomYLocation * RoomHeight * -1 + WallOffset + YMenuOffset + GridUnitSize * levelEvent.YLocation);
        }
        public static Vector2 CalculatePositionNoWallOffset(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + GridUnitSize * mapElement.XLocation, room.RoomYLocation * RoomHeight * -1 + YMenuOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculateNorthDoorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1) + NorthDoorPosition;
        }
        public static Vector2 CalculateEastDoorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1) + EastDoorPosition;
        }
        public static Vector2 CalculateSouthDoorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1) + SouthDoorPosition;
        }
        public static Vector2 CalculateWestDoorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1) + WestDoorPosition;
        }
        public static Vector2 CalculateExteriorPosition(Room room)
        {
            return new Vector2(room.RoomXLocation * RoomWidth, room.RoomYLocation * RoomHeight * -1 + YMenuOffset);
        }
        public static void GenerateExteriorColliders(Vector2 pos, Block block)
        {
            // North wall
            new RectCollider(new Rectangle((int)pos.X + WallOffset, (int)pos.Y, (RoomWidth - WallOffset * 2 - GridUnitSize) / 2, WallOffset), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle((int)pos.X + (RoomWidth + GridUnitSize) / 2, (int)pos.Y, (RoomWidth - WallOffset * 2 - GridUnitSize) / 2, WallOffset), CollisionLayer.OuterWall, block);

            // East wall
            new RectCollider(new Rectangle((int)pos.X + RoomWidth - WallOffset, (int)pos.Y + WallOffset, WallOffset, (RoomHeight - WallOffset * 2 - GridUnitSize) / 2), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle((int)pos.X + RoomWidth - WallOffset, (int)pos.Y + (RoomHeight + GridUnitSize) / 2, WallOffset, (RoomHeight - WallOffset * 2 - GridUnitSize) / 2), CollisionLayer.OuterWall, block);

            // South wall
            new RectCollider(new Rectangle((int)pos.X + WallOffset, (int)pos.Y + RoomHeight - WallOffset, (RoomWidth - WallOffset * 2 - GridUnitSize) / 2, WallOffset), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle((int)pos.X + (RoomWidth + GridUnitSize) / 2, (int)pos.Y + RoomHeight - WallOffset, (RoomWidth - WallOffset * 2 - GridUnitSize) / 2, WallOffset), CollisionLayer.OuterWall, block);

            // West wall
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + WallOffset, WallOffset, (RoomHeight - WallOffset * 2 - GridUnitSize) / 2), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + (RoomHeight + GridUnitSize) / 2, WallOffset, (RoomHeight - WallOffset * 2 - GridUnitSize) / 2), CollisionLayer.OuterWall, block);
        }
        public static void GenerateSpecialExteriorColliders(Vector2 pos, Block block)
        {
            // North wall
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, RoomWidth, GridUnitSize / 2), CollisionLayer.OuterWall, block);

            // East wall
            new RectCollider(new Rectangle((int)pos.X + RoomWidth - GridUnitSize / 2, (int)pos.Y, GridUnitSize / 2, RoomHeight), CollisionLayer.OuterWall, block);

            // South wall
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y + RoomHeight - GridUnitSize / 2, RoomWidth, GridUnitSize / 2), CollisionLayer.OuterWall, block);

            // West wall
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, GridUnitSize / 2, RoomHeight), CollisionLayer.OuterWall, block);
        }
        public static Vector2 CalculateWizardCenterPosition(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + WizardXPosition, room.RoomYLocation * RoomHeight * -1 + YMenuOffset + WallOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Vector2 CalculateTriforceCenterPosition(Room room, MapElement mapElement)
        {
            return new Vector2(room.RoomXLocation * RoomWidth + TriforceXPosition, room.RoomYLocation * RoomHeight * -1 + YMenuOffset + WallOffset + GridUnitSize * mapElement.YLocation);
        }
        public static Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.up: return Direction.down;
                case Direction.down: return Direction.up;
                case Direction.left: return Direction.right;
                case Direction.right: return Direction.left;
                default: return Direction.up;
            }
        }
    }
}