namespace LegendOfZelda
{
    public class RoomCycler
    {
        private static RoomCycler Instance;
        private static int index = 0;
        private RoomCycler()
        {
            index = LevelMaster.CurrentRoom;
            LevelMaster.GetInstance().NavigateToRoom(index);
        }
        public static RoomCycler GetInstance()
        {
            if (Instance == null)
                Instance = new RoomCycler();
            return Instance;
        }

        public void NextRoom()
        {
            index++;
            if (index > LevelMaster.NumberOfRooms - 1)
            {
                index = 0;
            }
            LevelMaster.GetInstance().NavigateToRoom(index);
        }

        public void PrevRoom()
        {
            index--;
            if (index < 0)
            {
                index = LevelMaster.NumberOfRooms - 1;
            }
            LevelMaster.GetInstance().NavigateToRoom(index);
        }
    }
}
