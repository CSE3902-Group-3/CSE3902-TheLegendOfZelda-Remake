using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LevelManager
    {
        private static LevelManager Instance;

        public static int CurrentLevel { get; private set; }
        public static int CurrentRoom { get; private set; }
        private static int PreviousRoom;
        public static int NumberOfRooms { get; private set; }
        public static Vector2 CurrentRoomPosition { get { return LevelRooms[CurrentRoom].RoomPosition; } }
        public static LevelRoom CurrentLevelRoom { get { return LevelRooms[CurrentRoom]; } }

        private static List<LevelRoom> LevelRooms;
        private static List<IUpdateable> PersistentUpdateables = new List<IUpdateable>();
        private static List<IDrawable> PersistentDrawables = new List<IDrawable>();
        private static List<IRectCollider> PersistentColliders = new List<IRectCollider>();
        private static List<List<AdjacentRoom>> RoomListAdjacentRooms;
        private LevelManager()
        {
            LevelRooms = new List<LevelRoom>
            {
                new LevelRoom()
            };
            CameraController.GetInstance().AddDrawablesToActiveMenuCamera(PersistentDrawables);
        }
        public static LevelManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LevelManager();
            }
            return Instance;
        }
        public void StartLevel(int levelNumber)
        {
            CurrentLevel = levelNumber;
            CameraController.GetInstance().AddDrawablesToForegroundOfMainCamera(PersistentDrawables);
            RoomList roomList = LevelParser.Parse("level" + levelNumber + ".json");
            NumberOfRooms = roomList.Rooms.Count;
            CurrentRoom = 0;
            LevelRooms = new List<LevelRoom>();
            RoomListAdjacentRooms = new List<List<AdjacentRoom>>();
            foreach (Room room in roomList.Rooms)
            {
                LevelRooms.Add(new LevelRoom());
                LevelRooms[CurrentRoom].LoadRoom(room);
                LevelRooms[CurrentRoom].SwitchOut();
                RoomListAdjacentRooms.Add(room.AdjacentRooms);
                CurrentRoom++;
            }
            CurrentRoom = 0;
        }
        public bool SnapToRoom(int targetRoom)
        {
            if (targetRoom >= 0 || targetRoom < NumberOfRooms)
            {
                LinkUtilities.LinkChangePosToRoom(LevelRooms[CurrentRoom].RoomPosition, LevelRooms[targetRoom].RoomPosition);
                CameraController.GetInstance().SnapCamToRoom(LevelRooms[targetRoom].RoomPosition);
                LevelRooms[CurrentRoom].DespawnEnemies();
                LevelRooms[CurrentRoom].SwitchOut();
                CurrentRoom = targetRoom;
                LevelRooms[CurrentRoom].SpawnEnemies();
                LevelRooms[CurrentRoom].SwitchIn();
                return true;
            }
            return false;
        }
        public bool TransitionToRoom(Direction direction)
        {
            int targetRoom = DetermineRoomInDirection(CurrentRoom, direction);
            if (targetRoom == CurrentRoom) { return false; }
            GameState.GetInstance().SwitchState(new RoomTransitionState());
            CameraController.GetInstance().PanCamToRoom(LevelRooms[targetRoom].RoomPosition, AfterRoomTransition);
            LevelRooms[CurrentRoom].DespawnEnemies();
            LevelRooms[CurrentRoom].UnfreezeAllEnemies();
            PreviousRoom = CurrentRoom;
            CurrentRoom = targetRoom;
            LevelRooms[CurrentRoom].SwitchIn();
            LevelRooms[CurrentRoom].OpenDoor(LevelUtilities.GetOppositeDirection(direction));
            return true;
        }
        public void AfterRoomTransition()
        {
            GameState.GetInstance().SwitchState(new NormalState());
            LevelRooms[CurrentRoom].SpawnEnemies();
            int temp = CurrentRoom;
            CurrentRoom = PreviousRoom;
            LevelRooms[CurrentRoom].SwitchOut();
            CurrentRoom = temp;
        }
        public void TransitionToStartingRoom(Action afterPan)
        {
            CurrentRoom = 0;
            CameraController.GetInstance().PanCamToRoom(LevelRooms[CurrentRoom].RoomPosition, afterPan);
            LevelRooms[CurrentRoom].SwitchIn();
        }
        private static int DetermineRoomInDirection(int fromRoom, Direction direction)
        {
            string directionString = DirectionToDirectionString(direction);
            foreach(AdjacentRoom adjacentRoom in RoomListAdjacentRooms[fromRoom])
            {
                if (adjacentRoom.Direction.Equals(directionString))
                {
                    return adjacentRoom.RoomNumber;
                }
            }
            return fromRoom;
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
        public static void Update(GameTime gameTime)
        {
            for (int i = PersistentUpdateables.Count - 1; i >= 0; i--)
            {
                PersistentUpdateables[i].Update(gameTime);
            }
            LevelRooms[CurrentRoom].Update(gameTime);
        }
        public static void KillAllEnemiesInCurrentRoom()
        {
            CurrentLevelRoom.KillAllEnemies();
        }
        public static void FreezeEnemiesInCurrentRoom()
        {
            CurrentLevelRoom.FreezeAllEnemies();
        }
        public static void UnfreezeEnemiesInCurrentRoom()
        {
            CurrentLevelRoom.UnfreezeAllEnemies();
        }
        public static bool AddDrawable(IDrawable drawable, bool persistent = false)
        {
            if (persistent && !PersistentDrawables.Contains(drawable))
            {
                PersistentDrawables.Add(drawable);
                return true;
            }
            else if (!persistent && LevelRooms[CurrentRoom].AddDrawable(drawable))
            {
                return true;
            }
            return false;
        }
        public static bool RemoveDrawable(IDrawable drawable, bool persistent = false)
        {
            if (persistent)
            {
                return PersistentDrawables.Remove(drawable);
            }
            else
            {
                return LevelRooms[CurrentRoom].RemoveDrawable(drawable);
            }
        }
        public static bool RemoveDrawable(IDrawable drawable, int room)
        {
            return LevelRooms[room].RemoveDrawable(drawable);
        }
        public static bool AddUpdateable(IUpdateable updateable, bool persistent = false)
        {
            if (persistent && !PersistentUpdateables.Contains(updateable))
            {
                PersistentUpdateables.Add(updateable);
                return true;
            }
            else if (!persistent && LevelRooms[CurrentRoom].AddUpdateable(updateable))
            {
                return true;
            }
            return false;
        }
        public static bool RemoveUpdateable(IUpdateable updateable, bool persistent = false)
        {
            if (persistent)
            {
                return PersistentUpdateables.Remove(updateable);
            }
            else
            {
                return LevelRooms[CurrentRoom].RemoveUpdateable(updateable);
            }
        }
        public static bool AddCollider(IRectCollider collider, bool persistent = false)
        {
            if (persistent && !PersistentColliders.Contains(collider))
            {
                PersistentColliders.Add(collider);
                return true;
            }
            else if (!persistent && LevelRooms[CurrentRoom].AddCollider(collider))
            {
                return true;
            }
            return false;
        }
        public static bool RemoveCollider(IRectCollider collider, bool persistent = false)
        {
            if (persistent)
            {
                return PersistentColliders.Remove(collider);
            }
            else
            {
                return LevelRooms[CurrentRoom].RemoveCollider(collider);
            }
        }
    }
}