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
            if (LevelManager.CurrentRoom == LevelManager.NumberOfRooms - 1)
            {
                LevelManager.GetInstance().SnapToRoom(0);
            }
            else
            {
                LevelManager.GetInstance().SnapToRoom(LevelManager.CurrentRoom + 1);
            }
        }

        public void PrevRoom()
        {
            if (LevelManager.CurrentRoom == 0)
            {
                LevelManager.GetInstance().SnapToRoom(LevelManager.NumberOfRooms - 1);
            }
            else
            {
                LevelManager.GetInstance().SnapToRoom(LevelManager.CurrentRoom - 1);
            }
        }
    }
}
