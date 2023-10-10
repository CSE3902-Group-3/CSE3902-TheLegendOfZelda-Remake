using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Room02 : IRoomID
    {
        private Game1 game;
        private RoomTexture roomTexture;

        private AnimatedSprite wall;
        private AnimatedSprite floor;

        public Room02()
        {
            this.game = Game1.getInstance();
            roomTexture = RoomTexture.getInstance();

            wall = roomTexture.CreateDungeonWall();
            floor = roomTexture.CreateDungeonFloor02();
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
