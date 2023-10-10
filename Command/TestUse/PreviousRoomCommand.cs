using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command.TestUse
{
    public class NextRoomCommand : ICommands
    {
        private RoomCycler roomCycler;

        public NextRoomCommand(RoomCycler roomCycler)
        {
            this.roomCycler = roomCycler;
        }

        public void Execute()
        {
            roomCycler.nextRoom();
        }
    }
}
