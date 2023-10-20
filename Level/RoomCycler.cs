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
        private LevelMaster lm;
        private int index = 0;
        public RoomCycler(LevelMaster lm)
        {
            this.lm = lm;
            lm.NavigateToRoom(index);
        }

        public void NextRoom()
        {
            index++;
            if (index > lm.GetRoomNumber() - 1)
            {
                index = 0;
            }
            lm.NavigateToRoom(index);
            Console.WriteLine("Navigate to room " + index);
        }

        public void PrevRoom()
        {
            index--;
            if (index < 0)
            {
                index = lm.GetRoomNumber() - 1;
            }
            lm.NavigateToRoom(index);
            Console.WriteLine("Navigate to room " + index);
        }
    }
}
