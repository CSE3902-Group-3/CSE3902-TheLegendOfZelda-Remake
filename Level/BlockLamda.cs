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
        private static int XOffset = 128; // x position starts at the edge of the wall
        private static int YOffset = 448; // y position starts at top menu height + edge of the wall, i.e. 320 + 128
        private static int Scale = 64; // size of a block
        private static Vector2 NorthDoorPosition = new Vector2(448, 320);
        private static Vector2 EastDoorPosition = new Vector2(896, 608);
        private static Vector2 SouthDoorPosition = new Vector2(448, 896);
        private static Vector2 WestDoorPosition = new Vector2(0, 608);

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
                WallExterior
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
            Block block = new Block(SpriteFactory.CreateFloorTileSprite(), new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation));
            block.enabled = true;
        }
        static void Wall(MapElement mapElement)
        {
            Vector2 pos = new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateWallSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void FishSculpture(MapElement mapElement)
        {
            Vector2 pos = new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateFishSculptureSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void DragonSculpture(MapElement mapElement)
        {
            Vector2 pos = new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateDragonSculptureSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void BlackTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateBlackTileSprite(), new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation));
            block.enabled = true;
        }
        static void SandTile(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSandTileSprite(), new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation));
            block.enabled = true;
        }
        static void BlueTile(MapElement mapElement)
        {
            Vector2 pos = new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBlueTileSprite(), new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation));
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void Stairs(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateStairsSprite(), new Vector2(XOffset + Scale * mapElement.XLocation, YOffset + Scale * mapElement.YLocation));
            block.enabled = true;
        }
        static void Brick(MapElement mapElement)
        {
            Vector2 pos = new Vector2(Scale * mapElement.XLocation, 320 + Scale * mapElement.YLocation);
            Block block = new Block(SpriteFactory.CreateBrickSprite(), pos);
            block.enabled = true;
            new RectCollider(new Rectangle((int)pos.X, (int)pos.Y, Scale, Scale), CollisionLayer.Wall, block);
        }
        static void WallNorth(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallNorthSprite(), NorthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)NorthDoorPosition.X, (int)NorthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void WallEast(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallEastSprite(), EastDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)EastDoorPosition.X, (int)EastDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void WallSouth(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallSouthSprite(), SouthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)SouthDoorPosition.X, (int)SouthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void WallWest(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallWestSprite(), WestDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)WestDoorPosition.X, (int)WestDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void NorthOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthOpenDoorSprite(), NorthDoorPosition);
            block.enabled = true;
        }
        static void EastOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastOpenDoorSprite(), EastDoorPosition);
            block.enabled = true;
        }
        static void SouthOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthOpenDoorSprite(), SouthDoorPosition);
            block.enabled = true;
        }
        static void WestOpenDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestOpenDoorSprite(), WestDoorPosition);
            block.enabled = true;
        }
        static void NorthLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthLockedDoorSprite(), NorthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)NorthDoorPosition.X, (int)NorthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void EastLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastLockedDoorSprite(), EastDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)EastDoorPosition.X, (int)EastDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void SouthLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthLockedDoorSprite(), SouthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)SouthDoorPosition.X, (int)SouthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void WestLockedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestLockedDoorSprite(), WestDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)WestDoorPosition.X, (int)WestDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void NorthClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthClosedDoorSprite(), NorthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)NorthDoorPosition.X, (int)NorthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void EastClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastClosedDoorSprite(), EastDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)EastDoorPosition.X, (int)EastDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void SouthClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthClosedDoorSprite(), SouthDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)SouthDoorPosition.X, (int)SouthDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void WestClosedDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestClosedDoorSprite(), WestDoorPosition);
            block.enabled = true;
            new RectCollider(new Rectangle((int)WestDoorPosition.X, (int)WestDoorPosition.Y, 128, 128), CollisionLayer.OuterWall, block);
        }
        static void NorthHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateNorthHoleDoorSprite(), NorthDoorPosition);
            block.enabled = true;
        }
        static void EastHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateEastHoleDoorSprite(), EastDoorPosition);
            block.enabled = true;
        }
        static void SouthHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateSouthHoleDoorSprite(), SouthDoorPosition);
            block.enabled = true;
        }
        static void WestHoleDoor(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWestHoleDoorSprite(), WestDoorPosition);
            block.enabled = true;
        }
        static void WallExterior(MapElement mapElement)
        {
            Block block = new Block(SpriteFactory.CreateWallExteriorSprite(), new Vector2(0, 320));
            block.enabled = true;

            // North wall collisions
            new RectCollider(new Rectangle(128, 320, 320, 128), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(576, 320, 320, 128), CollisionLayer.OuterWall, block);

            // South wall collisions
            new RectCollider(new Rectangle(128, 896, 320, 128), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(576, 896, 320, 128), CollisionLayer.OuterWall, block);

            // West wall collisions
            new RectCollider(new Rectangle(0, 448, 128, 160), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(0, 736, 128, 160), CollisionLayer.OuterWall, block);

            // East wall collisions
            new RectCollider(new Rectangle(896, 448, 128, 160), CollisionLayer.OuterWall, block);
            new RectCollider(new Rectangle(896, 736, 128, 160), CollisionLayer.OuterWall, block);
        }
    }
}
