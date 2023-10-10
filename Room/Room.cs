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

        private Dictionary<int, IRoomID> roomDictionary = new Dictionary<int, IRoomID>();

        public Room(Game1 game, int roomID)
        {
            this.game = game;
            roomTexture = RoomTexture.getInstance();
            this.roomID = roomID;

            roomDictionary.Add(1, new Room01());
            roomDictionary.Add(2, new Room02());
        }

        public void LoadTextures()
        {
            room = roomDictionary[roomID];
            wall = room.GetWallTexture();
            floor = room.GetFloorTexture();
            floor.UpdatePos(new Vector2(256, 176));
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
