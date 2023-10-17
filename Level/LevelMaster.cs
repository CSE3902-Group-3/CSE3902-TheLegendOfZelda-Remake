using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LevelMaster
    {
        private static LevelMaster Instance;
        private static Level CurrentLevel;
        private static RoomList RoomList { get; set; }
        public static int CurrentRoom { get; set; }
        public static List<List<IUpdateable>> RoomListUpdateables { get; set; }
        public static List<List<IDrawable>> RoomListDrawables { get; set; }
        public static List<IUpdateable> CurrentRoomUpdateables { get; set; }
        public static List<IDrawable> CurrentRoomDrawables { get; set; }
        private LevelMaster() 
        {
            RoomListUpdateables = new List<List<IUpdateable>>();
            RoomListDrawables = new List<List<IDrawable>>();
        }
        public static LevelMaster GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LevelMaster();
            }
            return Instance;
        }
        public bool NavigateToRoom(int roomNumber)
        {
            if (roomNumber >= 0 || roomNumber < RoomList.Rooms.Count)
            {
                CurrentRoom = roomNumber;
                CurrentRoomUpdateables = RoomListUpdateables[roomNumber];
                CurrentRoomDrawables = RoomListDrawables[roomNumber];
                return true;
            }
            return false;
        }
        public bool StartLevel(string filename)
        {
            if (CurrentLevel == null)
            {
                return false;
            } 
            else
            {
                CurrentLevel = new Level(filename);
                RoomList = CurrentLevel.RoomList;
                return true;
            }
        }
        public bool EndLevel()
        {
            if (CurrentLevel == null)
            {
                return false;
            }
            else
            {
                RoomListUpdateables = new List<List<IUpdateable>>();
                RoomListDrawables = new List<List<IDrawable>>();
                return true;
            }
        }
        public static void Update(GameTime gameTime)
        {
            foreach (IUpdateable updateable in RoomListUpdateables[CurrentRoom]) 
            {
                updateable.Update(gameTime);
            }
        }
        public static void Draw()
        {
            foreach (IDrawable drawable in RoomListDrawables[CurrentRoom])
            {
                drawable.Draw();
            }
        }
        public static bool RegisterDrawable(IDrawable drawable)
        {
            if (RoomListDrawables[CurrentRoom].Contains(drawable))
            {
                return false;
            }

            RoomListDrawables[CurrentRoom].Add(drawable);
            return true;
        }
        public static bool RegisterUpdateable(IUpdateable updateable)
        {
            if (RoomListUpdateables[CurrentRoom].Contains(updateable))
            {
                return false;
            }

            RoomListUpdateables[CurrentRoom].Add(updateable);
            return true;
        }
        public static bool RemoveDrawable(IDrawable drawable)
        {
            if (!RoomListDrawables[CurrentRoom].Contains(drawable))
            {
                return false;
            }

            RoomListDrawables[CurrentRoom].Remove(drawable);
            return true;
        }
        public static bool RemoveUpdateable(IUpdateable updateable)
        {
            if (!RoomListUpdateables[CurrentRoom].Contains(updateable))
            {
                return false;
            }
            RoomListUpdateables[CurrentRoom].Remove(updateable);
            return true;
        }
    }
}
