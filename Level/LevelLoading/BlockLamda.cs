using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class BlockLamda
    {
        public delegate void Lamda(Room room, MapElement mapElement);
        public Lamda[] BlockFunctionArray { get; }
        private static SpriteFactory SpriteFactory;
        private static BlockLamda Instance;
        
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
                MoveWestPushableBlock,
                MoveSouthPushableBlock,
                ImpassibleBlackTile,
                SpecialExteriorCollider,
                Fire
            };
        }
        public static BlockLamda GetInstance()
        {
            if (Instance == null)
                Instance = new BlockLamda();
            return Instance;
        }
        // Refer to Level/Levels/LevelWritingInstructions.txt for the dictionary
        static void FloorTile(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new Block(SpriteFactory.CreateFloorTileSprite(), pos);
        }
        static void Wall(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateWallSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        static void FishSculpture(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateFishSculptureSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        static void DragonSculpture(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateDragonSculptureSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        static void BlackTile(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new Block(SpriteFactory.CreateBlackTileSprite(), pos);
        }
        static void SandTile(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new Block(SpriteFactory.CreateSandTileSprite(), pos);
        }
        static void BlueTile(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateBlueTileSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        static void Stairs(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new Staircase(pos);
        }
        static void Brick(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionNoWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateBrickSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        static void WallNorth(Room room, MapElement mapElement)
        {
            new Wall(LevelUtilities.CalculateNorthDoorPosition(room), Direction.up);
        }
        static void WallEast(Room room, MapElement mapElement)
        {
            new Wall(LevelUtilities.CalculateEastDoorPosition(room), Direction.right);
        }
        static void WallSouth(Room room, MapElement mapElement)
        {
            new Wall(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        static void WallWest(Room room, MapElement mapElement)
        {
            new Wall(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
        }
        static void NorthOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(LevelUtilities.CalculateNorthDoorPosition(room), Direction.up);
        }
        static void EastOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(LevelUtilities.CalculateEastDoorPosition(room), Direction.right);
        }
        static void SouthOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        static void WestOpenDoor(Room room, MapElement mapElement)
        {
            new OpenDoor(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
        }
        static void NorthLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(LevelUtilities.CalculateNorthDoorPosition(room), Direction.up);
        }
        static void EastLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(LevelUtilities.CalculateEastDoorPosition(room), Direction.right);
        }
        static void SouthLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        static void WestLockedDoor(Room room, MapElement mapElement)
        {
            new LockedDoor(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
        }
        static void NorthClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(LevelUtilities.CalculateNorthDoorPosition(room), Direction.up);
        }
        static void EastClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(LevelUtilities.CalculateEastDoorPosition(room), Direction.right);
        }
        static void SouthClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        static void WestClosedDoor(Room room, MapElement mapElement)
        {
            new CloseableDoor(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
        }
        static void NorthHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(LevelUtilities.CalculateNorthDoorPosition(room), Direction.up);
        }
        static void EastHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(LevelUtilities.CalculateEastDoorPosition(room), Direction.right);
        }
        static void SouthHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(LevelUtilities.CalculateSouthDoorPosition(room), Direction.down);
        }
        static void WestHoleDoor(Room room, MapElement mapElement)
        {
            new BombableDoor(LevelUtilities.CalculateWestDoorPosition(room), Direction.left);
        }
        static void WallExterior(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculateExteriorPosition(room);
            Block block = new Block(SpriteFactory.CreateWallExteriorSprite(), pos);
            LevelUtilities.GenerateExteriorColliders(pos, block);
        }
        static void Ladder(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionNoWallOffset(room, mapElement);
            new Block(SpriteFactory.CreateLadderSprite(), pos);
        }
        static void LadderDoor(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionNoWallOffset(room, mapElement);
            new LadderDoor(pos);
        }
        static void MoveWestPushableBlock(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new MoveWestPushablBlock(pos);
        }
        static void MoveSouthPushableBlock(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            new MoveSouthPushableBlock(pos);
        }
        static void ImpassibleBlackTile(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateBlackTileSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
        // for rooms that need a thin exterior collider with no sprite, like room 12 in level 1
        static void SpecialExteriorCollider(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculateExteriorPosition(room);
            Block block = new Block(SpriteFactory.CreateWallExteriorSprite(), pos);
            block.Enabled = false;
            LevelUtilities.GenerateSpecialExteriorColliders(pos, block);
        }
        static void Fire(Room room, MapElement mapElement)
        {
            Vector2 pos = LevelUtilities.CalculatePositionWallOffset(room, mapElement);
            Block block = new Block(SpriteFactory.CreateFireSprite(), pos);
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, LevelUtilities.GridUnitSize, LevelUtilities.GridUnitSize), CollisionLayer.Wall, block);
        }
    }
}