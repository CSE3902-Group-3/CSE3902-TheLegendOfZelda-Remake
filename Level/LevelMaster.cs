using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LevelMaster
    {
        private static LevelMaster Instance;
        private static Level CurrentLevel;
        private static RoomList RoomList { get; set; }
        public static int CurrentRoom { get; set; }
        public static List<List<IUpdateable>> RoomListUpdateables { get; set; }
        public static List<List<IDrawable>> RoomListDrawables { get; set; }
        public static List<List<IRectCollider>> RoomListColliders { get; set; }
        public static List<IUpdateable> CurrentRoomUpdateables { get; set; }
        public static List<IDrawable> CurrentRoomDrawables { get; set; }
        public static List<IRectCollider> CurrentRoomColliders { get; set; }
        public static CollisionManager collisionManager;
        private LevelMaster() 
        {
            RoomListUpdateables = new List<List<IUpdateable>>();
            RoomListDrawables = new List<List<IDrawable>>();
            RoomListColliders = new List<List<IRectCollider>>();
            CurrentRoom = 0;
            collisionManager = CollisionManager.instance;
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
                SwapColliders(roomNumber);
                return true;
            }
            return false;
        }
        private void SwapColliders(int roomNumber)
        {
            if(CurrentRoomColliders != null)
            {
                foreach (IRectCollider collider in CurrentRoomColliders)
                {
                    collisionManager.RemoveRectCollider(collider);
                }
            }
            CurrentRoomColliders = RoomListColliders[roomNumber];
            foreach(IRectCollider collider in CurrentRoomColliders)
            {
                if (collider.Active)
                {
                    collisionManager.AddRectCollider(collider);
                }
            }
        }
        public bool StartLevel(string filename)
        {
            if (CurrentLevel == null)
            {
                CurrentLevel = new Level(filename);
                RoomList = CurrentLevel.RoomList;
                return true;
            } 
            else
            {
                return false;
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
                RoomListColliders = new List<List<IRectCollider>>();
                return true;
            }
        }
        public static void Update(GameTime gameTime)
        {
            for (int i = CurrentRoomUpdateables.Count - 1; i >= 0; i--)
            {
                CurrentRoomUpdateables[i].Update(gameTime);
            }
        }
        public static void Draw()
        {
            for (int i = 0; i < CurrentRoomDrawables.Count; i++)
            {
                CurrentRoomDrawables[i].Draw();
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
        public static bool RegisterCollider(IRectCollider collider)
        {
            if (RoomListColliders[CurrentRoom].Contains(collider))
            {
                return false;
            }

            RoomListColliders[CurrentRoom].Add(collider);
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
        public static bool RemoveCollider(IRectCollider collider)
        {
            if (!RoomListColliders[CurrentRoom].Contains(collider))
            {
                return false;
            }
            RoomListColliders[CurrentRoom].Remove(collider);
            return true;
        }
    }
}
