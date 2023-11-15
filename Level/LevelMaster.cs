using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class LevelMaster
    {
        private static LevelMaster Instance;

        public static int CurrentRoom { get { return currentRoom; } }
        private static int currentRoom;
        private static int previousRoom;
        public static int NumberOfRooms { get { return numberOfRooms; } }
        private static int numberOfRooms;
        public static Vector2 CurrentRoomPosition { get { return LevelRooms[currentRoom].RoomPosition; } }
        public static LevelRoom CurrentLevelRoom { get { return LevelRooms[currentRoom]; } }

        private static List<LevelRoom> LevelRooms;
        private static List<IUpdateable> PersistentUpdateables;
        private static List<IDrawable> PersistentDrawables;
        private static List<IRectCollider> PersistentColliders;
        private static List<List<AdjacentRoom>> RoomListAdjacentRooms;
        private LevelMaster(){}
        public static LevelMaster GetInstance()
        {
            if (Instance == null)
            {
                Instance = new LevelMaster();
            }
            return Instance;
        }
        public void StartLevel(string filename)
        {
            RoomList roomList = LevelParser.Parse(filename);
            numberOfRooms = roomList.Rooms.Count;
            currentRoom = 0;
            LevelRooms = new List<LevelRoom>();
            PersistentUpdateables = new List<IUpdateable>();
            PersistentDrawables = new List<IDrawable>();
            PersistentColliders = new List<IRectCollider>();
            RoomListAdjacentRooms = new List<List<AdjacentRoom>>();
            CameraController.GetInstance().AddPersistentDrawablesToMainCamera(PersistentDrawables);
            CameraController.GetInstance().AddDrawablesToActiveMenuCamera(PersistentDrawables);
            foreach (Room room in roomList.Rooms)
            {
                LevelRooms.Add(new LevelRoom());
                LevelRooms[currentRoom].LoadRoom(room);
                RoomListAdjacentRooms.Add(room.AdjacentRooms);

                currentRoom++;
            }
            currentRoom = 1;
        }
        public bool SnapToRoom(int targetRoom)
        {
            if (targetRoom >= 0 || targetRoom < NumberOfRooms)
            {
                LinkUtilities.LinkChangePosToRoom(LevelRooms[currentRoom].RoomPosition, LevelRooms[targetRoom].RoomPosition);
                CameraController.GetInstance().SnapCamToRoom(currentRoom, targetRoom, LevelRooms[targetRoom].RoomPosition);
                LevelRooms[currentRoom].DespawnEnemies();
                LevelRooms[currentRoom].SwitchOut();
                currentRoom = targetRoom;
                LevelRooms[currentRoom].SpawnEnemies();
                LevelRooms[currentRoom].SwitchIn();
                return true;
            }
            return false;
        }
        public bool TransitionToRoom(Direction direction)
        {
            int targetRoom = DetermineRoomInDirection(CurrentRoom, direction);
            if (targetRoom == CurrentRoom) { return false; }
            GameState.GetInstance().SwitchState(new RoomTransitionState());
            CameraController.GetInstance().PanCamToRoom(currentRoom, targetRoom, LevelRooms[targetRoom].RoomPosition, AfterRoomTransition);
            LevelRooms[currentRoom].DespawnEnemies();
            previousRoom = currentRoom;
            currentRoom = targetRoom;
            LevelRooms[currentRoom].SwitchIn();
            return true;
        }
        public void AfterRoomTransition()
        {
            GameState.GetInstance().SwitchState(new NormalState());
            LevelRooms[currentRoom].SpawnEnemies();
            int temp = currentRoom;
            currentRoom = previousRoom;
            LevelRooms[currentRoom].SwitchOut();
            currentRoom = temp;
            GameState.Link.ExitRoomTransition();
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
            LevelRooms[currentRoom].Update(gameTime);
        }
        public static bool AddDrawable(IDrawable drawable, bool persistent = false)
        {
            if (persistent && !PersistentDrawables.Contains(drawable))
            {
                PersistentDrawables.Add(drawable);
                return true;
            }
            else if (!persistent && LevelRooms[currentRoom].AddDrawable(drawable))
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
        public static bool AddUpdateable(IUpdateable updateable, bool persistent = false)
        {
            if (persistent && !PersistentUpdateables.Contains(updateable))
            {
                PersistentUpdateables.Add(updateable);
                return true;
            }
            else if (!persistent && LevelRooms[currentRoom].AddUpdateable(updateable))
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
            else if (!persistent && LevelRooms[currentRoom].AddCollider(collider))
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