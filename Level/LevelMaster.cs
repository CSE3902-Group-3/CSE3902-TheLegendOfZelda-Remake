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
        public static int CurrentRoom { get; set; }
        public static int NumberOfRooms { get; set; }
        public static List<List<IUpdateable>> RoomListUpdateables { get; set; }
        public static List<List<IDrawable>> RoomListDrawables { get; set; }
        public static List<List<IRectCollider>> RoomListColliders { get; set; }
        public static List<IUpdateable> CurrentRoomUpdateables { get; set; }
        public static List<IDrawable> CurrentRoomDrawables { get; set; }
        public static List<IRectCollider> CurrentRoomColliders { get; set; }
        public static CollisionManager collisionManager;
        private static BlockLamda BlockLamda = BlockLamda.GetInstance();
        private static ItemLamda ItemLamda = ItemLamda.GetInstance();
        private static EnemyLamda EnemyLamda = EnemyLamda.GetInstance();
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
            if (roomNumber >= 0 || roomNumber < NumberOfRooms)
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
            if (CurrentRoomColliders != null)
            {
                foreach (IRectCollider collider in CurrentRoomColliders)
                {
                    collisionManager.RemoveRectCollider(collider);
                }
            }
            CurrentRoomColliders = RoomListColliders[roomNumber];
            foreach (IRectCollider collider in CurrentRoomColliders)
            {
                if (collider.Active)
                {
                    collisionManager.AddRectCollider(collider);
                }
            }
        }
        private static void ProcessMapElement(MapElement mapElement)
        {
            switch (mapElement.ElementType)
            {
                case "Block":
                    BlockLamda.BlockFunctionArray[mapElement.ElementValue](mapElement);
                    break;
                case "Item":
                    ItemLamda.ItemFunctionArray[mapElement.ElementValue](mapElement);
                    break;
                case "Enemy":
                    EnemyLamda.EnemyFunctionArray[mapElement.ElementValue](mapElement);
                    break;
                default:
                    Console.WriteLine("INVALID MAP ELEMENT TYPE: " + mapElement.ElementType);
                    break;
            }
        }
        public void StartLevel(string filename)
        {
            RoomListUpdateables = new List<List<IUpdateable>>();
            RoomListDrawables = new List<List<IDrawable>>();
            RoomListColliders = new List<List<IRectCollider>>();
            RoomList roomList = LevelParser.Parse(filename);
            NumberOfRooms = roomList.Rooms.Count;
            for (int i = 0; i < roomList.Rooms.Count; i++)
            {
                CurrentRoom = i;
                RoomListUpdateables.Add(new List<IUpdateable>());
                RoomListDrawables.Add(new List<IDrawable>());
                RoomListColliders.Add(new List<IRectCollider>());
                foreach (MapElement mapElement in roomList.Rooms[i].MapElements)
                {
                    ProcessMapElement(mapElement);
                }

                //Deactivate colliders (since most objects are not in the first room)
                foreach (IRectCollider rectCollider in RoomListColliders[i])
                {
                    collisionManager.RemoveRectCollider(rectCollider);
                }
            }
            CurrentRoom = 0;
        }
        public static void Update(GameTime gameTime)
        {
            //Create unchangeable list of updateables
            List<IUpdateable> thisFrameUpdates = CurrentRoomUpdateables.ToList();
            for (int i = thisFrameUpdates.Count - 1; i >= 0; i--)
            {
                if (thisFrameUpdates[i] != null)
                {
                    thisFrameUpdates[i].Update(gameTime);
                }
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
            if (RoomListDrawables == null || RoomListDrawables[CurrentRoom].Contains(drawable))
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
            if (RoomListColliders == null || RoomListColliders[CurrentRoom].Contains(collider))
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
