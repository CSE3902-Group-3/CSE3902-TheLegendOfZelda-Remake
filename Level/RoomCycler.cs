using System;
using System.Reflection;

namespace LegendOfZelda
{
    public class RoomCycler
    {
        private static RoomCycler Instance;
        private RoomCycler(){}
        public static RoomCycler GetInstance()
        {
            if (Instance == null)
                Instance = new RoomCycler();
            return Instance;
        }

        public void NextRoom()
        {
            if (LevelMaster.CurrentRoom == LevelMaster.NumberOfRooms - 1)
            {
                LevelMaster.GetInstance().NavigateToRoom(0);
            }
            else
            {
                LevelMaster.GetInstance().NavigateToRoom(LevelMaster.CurrentRoom + 1);
            }
        }

        public void PrevRoom()
        {
            if (LevelMaster.CurrentRoom == 0)
            {
                LevelMaster.GetInstance().NavigateToRoom(LevelMaster.NumberOfRooms - 1);
            }
            else
            {
                LevelMaster.GetInstance().NavigateToRoom(LevelMaster.CurrentRoom - 1);
            }
        }
    }
}
