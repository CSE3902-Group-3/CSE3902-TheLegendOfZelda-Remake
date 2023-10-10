using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Room01 : IRoomID
    {
        private Game1 game;
        private RoomTexture roomTexture;

        private AnimatedSprite wall;
        private AnimatedSprite floor;

        public Room01()
        {
            this.game = Game1.getInstance();
            roomTexture = RoomTexture.getInstance();

            wall = roomTexture.CreateDungeonWall();
            floor = roomTexture.CreateDungeonFloor01();
        }

        public AnimatedSprite GetWallTexture()
        {
            return wall;
        }

        public AnimatedSprite GetFloorTexture()
        {
            return floor;
        }
    }
}
