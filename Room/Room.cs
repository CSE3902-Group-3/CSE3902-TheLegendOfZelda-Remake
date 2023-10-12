using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Room : IRoom
    {
        private Game1 game;
        private RoomTexture roomTexture;
        private int roomID;
        private IRoomID room;

        private AnimatedSprite wall;
        private AnimatedSprite floor;

        // To be implemented
        private List<IItem> items;
        private List<IEnemy> enemies;
        private List<Block> blocks;

        private List<AnimatedSprite> dungeonSprites;

        private const int SCALE = 6;
        private const int WALL_WIDTH = 256;
        private const int WALL_HEIGHT = 176;
        private const int WALL_THICKNESS = 32;

        private int Wall_Pos_X;
        private int Wall_Pos_Y;
        private int Floor_Pos_X;
        private int Floor_Pos_Y;

        private Dictionary<int, IRoomID> roomDictionary = new Dictionary<int, IRoomID>();

        public Room(Game1 game, int roomID)
        {
            this.game = game;
            //roomTexture = game.roomTexture;
            this.roomID = roomID;

            roomDictionary.Add(1, new Room01());
            roomDictionary.Add(2, new Room02());
            roomDictionary.Add(3, new Room03());

        }

        public void Compute_Pos()
        {
            Wall_Pos_X = (int)((game.GraphicsDevice.Viewport.Width - WALL_WIDTH * SCALE) / 2);
            Wall_Pos_Y = (int)((game.GraphicsDevice.Viewport.Height - WALL_HEIGHT * SCALE) / 2);
            Floor_Pos_X = (int)(Wall_Pos_X + WALL_THICKNESS * SCALE);
            Floor_Pos_Y = (int)(Wall_Pos_Y + WALL_THICKNESS * SCALE);
        }

        public void LoadTextures()
        {
            Compute_Pos();
            room = roomDictionary[roomID];
            wall = room.GetWallTexture();
            floor = room.GetFloorTexture();
            wall.UpdatePos(new Vector2(Wall_Pos_X, Wall_Pos_Y));
            floor.UpdatePos(new Vector2(Floor_Pos_X, Floor_Pos_Y));
        }

        public void Update(int newRoomID)
        {
            Clear();
            this.roomID = newRoomID;
            
            LoadTextures();
            wall.RegisterSprite();
            floor.RegisterSprite();
            //Draw();
        }

        /*
        public void Draw()
        {
            LoadTextures();
            wall.RegisterSprite();
            floor.RegisterSprite();
            floor.UpdatePos(new Vector2(256, 176));
        }
        */

        public void Clear()
        {
            wall.UnregisterSprite();
            floor.UnregisterSprite();
        }
    }
}
