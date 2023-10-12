using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class RoomCycler
    {
        private Room room;

        private int index = 1;

        public RoomCycler()
        {
            room = new Room(Game1.getInstance(), index);
            room.LoadTextures();
        }

        public void nextRoom()
        {
            index++;
            if (index > 3)
            {
                index = 1;
            }
            room.Update(index);
            //room.Clear();
            //room.Draw();
        }

        public void prevRoom()
        {
            index--;
            if (index < 1)
            {
                index = 3;
            }
            room.Update(index);
            //room.Clear();
            //room.Draw();
        }

        public void Clear()
        {
            room.Clear();
        }
    }
}
