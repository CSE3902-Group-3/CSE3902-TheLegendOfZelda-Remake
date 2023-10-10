using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.TestUse
{
    public class PreviousRoomCommand : ICommands
    {
        private RoomCycler roomCycler;

        public PreviousRoomCommand(RoomCycler roomCycler)
        {
            this.roomCycler = roomCycler;
        }

        public void Execute()
        {
            roomCycler.prevRoom();
        }
    }
}
