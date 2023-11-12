using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class BlockLamda
    {
        public delegate void Lamda(Room room, MapElement mapElement);
        public Lamda[] BlockFunctionArray { get; }
        private static SpriteFactory SpriteFactory;
        private static BlockLamda Instance;
        private static int YMenuOffset = 320; // y offset for menu
        private static int WallThickness = 128; // x position starts at the edge of the wall
        private static int Room12ColliderThickness = 10;
        private static int YOffset = YMenuOffset + WallThickness; // y position starts at top menu height + edge of the wall, i.e. 320 + 128
        private static int XRightWallOffset = 576;
        private static int Scale = 64; // size of a block
        private static Vector2 NorthDoorPosition = new Vector2(448, 320);
        private static Vector2 EastDoorPosition = new Vector2(896, 608);
        private static Vector2 SouthDoorPosition = new Vector2(448, 896);
        private static Vector2 WestDoorPosition = new Vector2(0, 608);
        private static int NorthSouthWallHeight = 128;
        private static int NorthSouthWallWidth = 320;
        private static int EastWestWallHeight = 160;
        private static int EastWestWallWidth = 128;
        private static int EastWestSouthWallOffset = 736;
        private static int ViewportSideLength = 1024;
        private BlockLamda()
        {
            SpriteFactory = SpriteFactory.getInstance();
            BlockFunctionArray = new Lamda[]
            {
                FloorTile,
                Wall,
                FishSculpture,
                DragonSculpture,
                BlackTile,
                SandTile,
                BlueTile,
                Stairs,
                Brick,
                WallNorth,
                WallEast,
                WallSouth,
                WallWest,
                NorthOpenDoor,
                EastOpenDoor,
                SouthOpenDoor,
                WestOpenDoor,
                NorthLockedDoor,
                EastLockedDoor,
                SouthLockedDoor,
                WestLockedDoor,
                NorthClosedDoor,
                EastClosedDoor,
                SouthClosedDoor,
                WestClosedDoor,
                NorthLockedDoor,
                EastLockedDoor,
                SouthLockedDoor,
                WestLockedDoor,
                NorthHoleDoor,
                EastHoleDoor,
                SouthHoleDoor,
                WestHoleDoor,
                WallExterior,
                Ladder,
                LadderDoor,
                Room8PushableBlock,
                Room16PushableBlock,
                ImpassibleBlackTile,
                Room12ExteriorCollider
            };
        }
        public static BlockLamda GetInstance()
        {
            if (Instance == null)
                Instance = new BlockLamda();
            return Instance;
        }
        static void FloorTile(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateFloorTileSprite(), pos);
            block.enabled = true;
        }
        static void Wall(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateWallSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void FishSculpture(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateFishSculptureSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void DragonSculpture(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateDragonSculptureSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void BlackTile(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBlackTileSprite(), pos);
            block.enabled = true;
        }
        static void SandTile(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateSandTileSprite(), pos);
            block.enabled = true;
        }
        static void BlueTile(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBlueTileSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void Stairs(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            new Staircase(pos);
        }
        static void Brick(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + Scale * mapElement.XLocation, room.RoomYLocation + YMenuOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBrickSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void WallNorth(Room room, MapElement mapElement)
        {
            new Wall(new Vector2(room.RoomXLocation, room.RoomYLocation) + NorthDoorPosition, Direction.up);
        }
        static void WallEast(Room room, MapElement mapElement)
        {
            new Wall(new Vector2(room.RoomXLocation, room.RoomYLocation) + EastDoorPosition, Direction.right);
        }
        static void WallSouth(Room room, MapElement mapElement)
        {
            new Wall(new Vector2(room.RoomXLocation, room.RoomYLocation) + SouthDoorPosition, Direction.down);
        }
        static void WallWest(Room room, MapElement mapElement)
        {
            new Wall(new Vector2(room.RoomXLocation, room.RoomYLocation) + WestDoorPosition, Direction.left);
        }
        static void NorthOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + NorthDoorPosition, Direction.up);
        }
        static void EastOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + EastDoorPosition, Direction.right);
        }
        static void SouthOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + SouthDoorPosition, Direction.down);
        }
        static void WestOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + WestDoorPosition, Direction.left);
        }
        static void NorthLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + NorthDoorPosition, Direction.up);
        }
        static void EastLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + EastDoorPosition, Direction.right);
        }
        static void SouthLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + SouthDoorPosition, Direction.down);
        }
        static void WestLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + WestDoorPosition, Direction.left);
        }
        static void NorthClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + NorthDoorPosition, Direction.up);
        }
        static void EastClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + EastDoorPosition, Direction.right);
        }
        static void SouthClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + SouthDoorPosition, Direction.down);
        }
        static void WestClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + WestDoorPosition, Direction.left);
        }
        static void NorthHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + NorthDoorPosition, Direction.up);
        }
        static void EastHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + EastDoorPosition, Direction.right);
        }
        static void SouthHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + SouthDoorPosition, Direction.down);
        }
        static void WestHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(new Vector2(room.RoomXLocation, room.RoomYLocation) + WestDoorPosition, Direction.left);
        }
        static void WallExterior(Room room, MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallExteriorSprite(), new Vector2(room.RoomXLocation, room.RoomYLocation + YMenuOffset));
            block.enabled = true;

            // North wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + WallThickness, room.RoomYLocation + YMenuOffset, NorthSouthWallWidth, NorthSouthWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + XRightWallOffset, room.RoomYLocation + YMenuOffset, NorthSouthWallWidth, NorthSouthWallHeight), CollisionLayer.OuterWall, block);

            // South wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + WallThickness, room.RoomYLocation + ViewportSideLength - WallThickness, NorthSouthWallWidth, NorthSouthWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + XRightWallOffset, room.RoomYLocation + ViewportSideLength - WallThickness, NorthSouthWallWidth, NorthSouthWallHeight), CollisionLayer.OuterWall, block);

            // West wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation, room.RoomYLocation + YOffset, EastWestWallWidth, EastWestWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation, room.RoomYLocation + EastWestSouthWallOffset, EastWestWallWidth, EastWestWallHeight), CollisionLayer.OuterWall, block);

            // East wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + ViewportSideLength - WallThickness, room.RoomYLocation + YOffset, EastWestWallWidth, EastWestWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + ViewportSideLength - WallThickness, room.RoomYLocation + EastWestSouthWallOffset, EastWestWallWidth, EastWestWallHeight), CollisionLayer.OuterWall, block);
        }
        static void Ladder(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + Scale * mapElement.XLocation, room.RoomYLocation + YMenuOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateLadderSprite(), pos);
            block.enabled = true;
        }
        static void LadderDoor(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + Scale * mapElement.XLocation, room.RoomYLocation + YMenuOffset + Scale * mapElement.YLocation);
            new LadderDoor(pos);
        }
        static void Room8PushableBlock(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            new Room8PushableBlock(pos);
        }
        static void Room16PushableBlock(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            new Room16PushableBlock(pos);
        }
        static void ImpassibleBlackTile(Room room, MapElement mapElement)
        {
            Vector2 pos = new Vector2(room.RoomXLocation + WallThickness + Scale * mapElement.XLocation, room.RoomYLocation + YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBlackTileSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void Room12ExteriorCollider(Room room, MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallExteriorSprite(), new Vector2(room.RoomXLocation, room.RoomYLocation + YMenuOffset));

            // North wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + WallThickness, room.RoomYLocation + YMenuOffset, NorthSouthWallWidth, Room12ColliderThickness), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + XRightWallOffset, room.RoomYLocation + YMenuOffset, NorthSouthWallWidth, Room12ColliderThickness), CollisionLayer.OuterWall, block);

            // South wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + WallThickness, room.RoomYLocation + ViewportSideLength - WallThickness, NorthSouthWallWidth, Room12ColliderThickness), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + XRightWallOffset, room.RoomYLocation + ViewportSideLength - WallThickness, NorthSouthWallWidth, Room12ColliderThickness), CollisionLayer.OuterWall, block);

            // West wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation, room.RoomYLocation + YOffset, Room12ColliderThickness, EastWestWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation, room.RoomYLocation + EastWestSouthWallOffset, Room12ColliderThickness, EastWestWallHeight), CollisionLayer.OuterWall, block);

            // East wall collisions
            new RectCollider(new Rectangle(room.RoomXLocation + ViewportSideLength - WallThickness, room.RoomYLocation + YOffset, Room12ColliderThickness, EastWestWallHeight), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(room.RoomXLocation + ViewportSideLength - WallThickness, room.RoomYLocation + EastWestSouthWallOffset, Room12ColliderThickness, EastWestWallHeight), CollisionLayer.OuterWall, block);
        }
    }
}
