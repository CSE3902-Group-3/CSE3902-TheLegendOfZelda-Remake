using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LevelMaster
    {
        private static LevelMaster Instance;
        public static int RoomWidth = 1024;
        public static int RoomHeight = 704;
        public static int CurrentRoom { get; set; }
        public static int NumberOfRooms { get; set; }
        public static int brickRoom = 12;
        public static int brickRoomEntrance = 16;

        public static List<List<IDrawable>> RoomListDrawables { get; set; } 
        public static List<IDrawable> CurrentRoomDrawables { get; set; }
        public static List<IDrawable> PersistentDrawables { get; set; }

        public static List<List<IRectCollider>> RoomListColliders { get; set; }
        public static List<IRectCollider> CurrentRoomColliders { get; set; }
        public static List<IRectCollider> PersistentColliders { get; set; }

        public static List<List<IUpdateable>> RoomListUpdateables { get; set; }
        public static List<IUpdateable> CurrentRoomUpdateables { get; set; }
        public static List<IUpdateable> PersistentUpdateables { get; set; }

        public static List<Vector2> RoomPositionList { get; set; }
        public static List<List<IEnemy>> EnemiesList;

        private static BlockLamda BlockLamda = BlockLamda.GetInstance();
        private static ItemLamda ItemLamda = ItemLamda.GetInstance();
        private static EnemyLamda EnemyLamda = EnemyLamda.GetInstance();
        private static EventLamda EventLamda = EventLamda.GetInstance();
        
        private static RoomList roomList;
        private LevelMaster(){}
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
                LinkUtilities.LinkChangePosToRoom(RoomPositionList[CurrentRoom], RoomPositionList[roomNumber]);
                CurrentRoomUpdateables = RoomListUpdateables[roomNumber];
                CurrentRoomDrawables = RoomListDrawables[roomNumber];
                SwapColliders(roomNumber);
                CameraController.GetInstance().SnapCamToRoom(CurrentRoom, roomNumber, RoomPositionList[roomNumber]);
                DespawnEnemiesFromCurrentRoom();
                CurrentRoom = roomNumber;
                SpawnEnemiesToCurrentRoom();
                return true;
            }
            return false;
        }

        public bool NavigateInDirection(Direction direction, Action onNavComplete = null)
        {
            int targetRoom = DetermineRoomInDirection(CurrentRoom, direction);
            if(targetRoom == CurrentRoom)
            {
                return false;
            }

            CurrentRoomUpdateables = RoomListUpdateables[targetRoom];
            CurrentRoomDrawables = RoomListDrawables[targetRoom];
            SwapColliders(targetRoom);

            GameState.GetInstance().SwitchState(new RoomTransitionState());
            DespawnEnemiesFromCurrentRoom();
            CameraController.GetInstance().PanCamToRoom(CurrentRoom, targetRoom, RoomPositionList[targetRoom], AfterPan);
            CurrentRoom = targetRoom;
            return true;
        }
        public void AfterPan ()
        {
            CameraController.GetInstance().RemovePreviousRoomDrawables();
            GameState.GetInstance().SwitchState(new NormalState());
            SpawnEnemiesToCurrentRoom();
        }
        private static int DetermineRoomInDirection(int startingRoom, Direction direction)
        {
            List<AdjacentRoom> adjacentRooms = roomList.Rooms[startingRoom].AdjacentRooms;
            string directionString = DirectionToDirectionString(direction);
            foreach(AdjacentRoom adjacentRoom in adjacentRooms)
            {
                if (adjacentRoom.Direction.Equals(directionString))
                {
                    return adjacentRoom.RoomNumber;
                }
            }

            return startingRoom;
        }

        private static string DirectionToDirectionString(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    return "North";
                case Direction.down:
                    return "South";
                case Direction.left:
                    return "West";
                case Direction.right:
                    return "East";
                default:
                    return "other";
            }
        }

        private static void SwapColliders(int roomNumber)
        {
            if (CurrentRoomColliders != null)
            {
                foreach (IRectCollider collider in CurrentRoomColliders)
                {
                    GameState.CollisionManager.RemoveRectCollider(collider);
                }
            }
            CurrentRoomColliders = RoomListColliders[roomNumber];
            foreach (IRectCollider collider in CurrentRoomColliders)
            {
                if (collider.Active)
                {
                    GameState.CollisionManager.AddRectCollider(collider);
                }
            }
        }
        private static void ProcessMapElement(Room room, MapElement mapElement)
        {

            switch (mapElement.ElementType)
            {
                case "Block":
                    BlockLamda.BlockFunctionArray[mapElement.ElementValue](room, mapElement);
                    break;
                case "Item":
                    ItemLamda.ItemFunctionArray[mapElement.ElementValue](room, mapElement);
                    break;
                case "Enemy":
                    EnemyLamda.EnemyFunctionArray[mapElement.ElementValue](room, mapElement);
                    break;
                default:
                    Console.WriteLine("INVALID MAP ELEMENT TYPE: " + mapElement.ElementType);
                    break;
            }
        }
        public void StartLevel(string filename)
        {
            RoomListUpdateables = new List<List<IUpdateable>>();
            PersistentUpdateables = new List<IUpdateable>();
            RoomListDrawables = new List<List<IDrawable>>();
            PersistentDrawables = new List<IDrawable>();
            RoomListColliders = new List<List<IRectCollider>>();
            PersistentColliders = new List<IRectCollider>();
            RoomPositionList = new List<Vector2>();
            EnemiesList = new List<List<IEnemy>>();
            roomList = LevelParser.Parse(filename);
            NumberOfRooms = roomList.Rooms.Count;
            CurrentRoom = 0;
            foreach (Room room in roomList.Rooms)
            {
                room.RoomXLocation *= RoomWidth;
                room.RoomYLocation *= RoomHeight * -1;
                RoomPositionList.Add(new Vector2(room.RoomXLocation, room.RoomYLocation));
                EnemiesList.Add(new List<IEnemy>());
                RoomListUpdateables.Add(new List<IUpdateable>());
                RoomListDrawables.Add(new List<IDrawable>());
                RoomListColliders.Add(new List<IRectCollider>());
                if (room.Events != null)
                {
                    foreach (LevelEvent levelEvent in room.Events)
                    {
                        EventLamda.EventFunctionArray[levelEvent.EventNumber](room, levelEvent);
                    }
                }
                foreach (MapElement mapElement in room.MapElements)
                {
                    ProcessMapElement(room, mapElement);
                }

                //Deactivate colliders (since most objects are not in the first room)
                foreach (IRectCollider rectCollider in RoomListColliders[CurrentRoom])
                {
                    GameState.CollisionManager.RemoveRectCollider(rectCollider);
                }
                CurrentRoom++;
            }
            CurrentRoom = 0;
        }
        public void SpawnEnemiesToCurrentRoom()
        {
            foreach (IEnemy enemy in EnemiesList[CurrentRoom])
            {
                enemy.Spawn();
            }
        }
        public void DespawnEnemiesFromCurrentRoom()
        {
            foreach (IEnemy enemy in EnemiesList[CurrentRoom])
            {
                enemy.Die();
            }
        }
        public static void Update(GameTime gameTime)
        {
            //Create unchangeable list of updateables to prevent loop being messed with during updating
            List<IUpdateable> thisFramePersisitantUpdates = PersistentUpdateables;
            for (int i = thisFramePersisitantUpdates.Count - 1; i >= 0; i--)
            {
                if (thisFramePersisitantUpdates[i] != null)
                {
                    thisFramePersisitantUpdates[i].Update(gameTime);
                }
            }

            List<IUpdateable> thisFrameUpdates = CurrentRoomUpdateables;
            for (int i = thisFrameUpdates.Count - 1; i >= 0; i--)
            {
                if (thisFrameUpdates[i] != null)
                {
                    thisFrameUpdates[i].Update(gameTime);
                }
            }
        }
        public static bool RegisterDrawable(IDrawable drawable, bool persistent = false)
        {
            if (persistent)
            {
                if (PersistentDrawables.Contains(drawable))
                {
                    return false;
                }

                PersistentDrawables.Add(drawable);
            }
            else
            {
                if (RoomListDrawables[CurrentRoom].Contains(drawable))
                {
                    return false;
                }

                RoomListDrawables[CurrentRoom].Add(drawable);
            }
            return true;
        }
        public static bool RegisterUpdateable(IUpdateable updateable, bool persistent = false)
        {
            if (persistent)
            {
                if (PersistentUpdateables.Contains(updateable))
                {
                    return false;
                }

                PersistentUpdateables.Add(updateable);
            }
            else
            {
                if (RoomListUpdateables[CurrentRoom].Contains(updateable))
                {
                    return false;
                }

                RoomListUpdateables[CurrentRoom].Add(updateable);
            }
            return true;
        }
        public static bool RegisterCollider(IRectCollider collider, bool persistent = false)
        {
            if (persistent)
            {
                if (PersistentColliders == null || PersistentColliders.Contains(collider))
                {
                    return false;
                }

                PersistentColliders.Add(collider);
            }
            else
            {
                if (RoomListColliders == null || RoomListColliders[CurrentRoom].Contains(collider))
                {
                    return false;
                }

                RoomListColliders[CurrentRoom].Add(collider);
            }
            return true;
        }
        public static bool RemoveDrawable(IDrawable drawable, bool persistent = false)
        {
            if (persistent)
            {
                if (!PersistentDrawables.Contains(drawable))
                {
                    return false;
                }

                PersistentDrawables.Remove(drawable);
            }
            else
            {
                if (!RoomListDrawables[CurrentRoom].Contains(drawable))
                {
                    return false;
                }

                RoomListDrawables[CurrentRoom].Remove(drawable);
            }
            return true;
        }
        public static bool RemoveUpdateable(IUpdateable updateable, bool persistent = false)
        {
            if (persistent)
            {
                if (!PersistentUpdateables.Contains(updateable))
                {
                    return false;
                }

                PersistentUpdateables.Remove(updateable);
            }
            else
            {
                if (!RoomListUpdateables[CurrentRoom].Contains(updateable))
                {
                    return false;
                }

                RoomListUpdateables[CurrentRoom].Remove(updateable);
            }
            return true;
        }
        public static bool RemoveCollider(IRectCollider collider, bool persistent = false)
        {
            if (persistent)
            {
                if (!PersistentColliders.Contains(collider))
                {
                    return false;
                }
                PersistentColliders.Remove(collider);
            }
            else
            {
                if (!RoomListColliders[CurrentRoom].Contains(collider))
                {
                    return false;
                }

                RoomListColliders[CurrentRoom].Remove(collider);
            }
            return true;
        }
    }
}
