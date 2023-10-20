using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class RoomCycler
    {
        private Level level;
        private int index = 0;
        public RoomCycler(Level level)
        {
            this.level = level;
            level.NavigateToRoom(index);
        }

        public void NextRoom()
        {
            index++;
            if (index > level.GetRoomNumber())
            {
                index = 0;
            }
            level.NavigateToRoom(index);
            Console.WriteLine("Navigate to room " + index);
        }

        public void PrevRoom()
        {
            index--;
            if (index < 0)
            {
                index = level.GetRoomNumber() - 1;
            }
            level.NavigateToRoom(index);
            Console.WriteLine("Navigate to room " + index);
        }
    }
}
