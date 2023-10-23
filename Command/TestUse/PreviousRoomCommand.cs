using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class PreviousRoomCommand : ICommands
    {
        RoomCycler roomCycler;

        public PreviousRoomCommand(RoomCycler roomCycler)
        {
            this.roomCycler = roomCycler;
        }

        public void Execute()
        {
            roomCycler.PrevRoom();
        }
    }
}
