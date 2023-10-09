using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class BlockLamda
    {
        public delegate void Lamda(MapElement mapElement);
        public Lamda[] BlockFunctionArray { get; }
        private static SpriteFactory SpriteFactory;
        private static BlockLamda Instance;
        private static int Scale = Level.Scale;
        /**
         * Block Lamda Function Dictionary
         * 
         * FloorTile, 0
         * Wall, 1
         * FishSculpture, 2
         * DragonSculpture, 3
         * BlackTile, 4
         * SandTile, 5
         * BlueTile, 6
         * Stairs, 7 
         * Brick, 8 
         * WallNorth, 9
         * WallEast, 10
         * WallSouth, 11
         * WallWest, 12
         * NorthOpenDoor, 13
         * EastOpenDoor, 14
         * SouthOpenDoor, 15
         * WestOpenDoor, 16
         * NorthLockedDoor, 17
         * EastLockedDoor, 18
         * SouthLockedDoor, 19
         * WestLockedDoor, 20
         * NorthClosedDoor, 21
         * EastClosedDoor, 22
         * SouthClosedDoor, 23
         * WestClosedDoor, 24
         * NorthLockedDoor, 25
         * EastLockedDoor, 26
         * SouthLockedDoor, 27
         * WestLockedDoor, 28
         * NorthHoleDoor, 29
         * EastHoleDoor, 30
         * SouthHoleDoor, 31
         * WestHoleDoor, 32
         */
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
                WestHoleDoor
            };
        }
        public static BlockLamda GetInstance()
        {
            if (Instance == null)
                Instance = new BlockLamda();
            return Instance;
        }
        static void FloorTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateFloorTileSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void Wall(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void FishSculpture(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateFishSculptureSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void DragonSculpture(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateDragonSculptureSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void BlackTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateBlackTileSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void SandTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSandTileSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void BlueTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateBlueTileSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void Stairs(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateStairsSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void Brick(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateBrickSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WallNorth(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallNorthSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WallEast(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallEastSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WallSouth(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallSouthSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WallWest(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallWestSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void NorthOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthOpenDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void EastOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastOpenDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void SouthOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthOpenDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WestOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestOpenDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void NorthLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthLockedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void EastLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastLockedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void SouthLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthLockedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WestLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestLockedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void NorthClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthClosedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void EastClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastClosedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void SouthClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthClosedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WestClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestClosedDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void NorthHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthHoleDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void EastHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastHoleDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void SouthHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthHoleDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
        static void WestHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestHoleDoorSprite(), new Vector2(mapElement.XLocation * Scale, mapElement.YLocation * Scale));
            block.enabled = true;
        }
    }
}
