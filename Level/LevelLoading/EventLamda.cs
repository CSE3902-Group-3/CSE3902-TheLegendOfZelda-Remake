﻿using LegendOfZelda.Level;

namespace LegendOfZelda
{
    public class EventLamda
    {
        public delegate void Lamda(Room room, LevelEvent levelEvent);
        public Lamda[] EventFunctionArray { get; }
        private static EventLamda Instance;
        private EventLamda()
        {
            EventFunctionArray = new Lamda[]
            {
                AllEnemiesDeadKeyDrop,
                AllEnemiesDeadBoomerangDrop,
                AllEnemiesDeadOpenEastDoor,
                PushBlockWestOpenWestDoor,
                AllEnemiesDeadOpenWestDoor,
                AllEnemiesDeadOpenSouthDoor,
                AllEnemiesDeadOpenNorthDoor,
                CloseStartingDoorAfterStart,
                AllEnemiesDeadHeartContainerDrop
            };
        }
        public static EventLamda GetInstance()
        {
            if (Instance == null)
                Instance = new EventLamda();
            return Instance;
        }
        // There is no ordering to the events, they are just added as needed
        // Refer to Level/Levels/LevelWritingInstructions.txt for the dictionary
        public static void AllEnemiesDeadKeyDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadKeyDropEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
        public static void AllEnemiesDeadBoomerangDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadBoomerangDropEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
        public static void AllEnemiesDeadOpenEastDoor(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadOpenClosedEastDoorEvent(room);
        }
        public static void PushBlockWestOpenWestDoor(Room room, LevelEvent levelEvent)
        {
            new PushBlockWestOpenWestClosedDoorEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent), room);
        }
        public static void AllEnemiesDeadOpenWestDoor(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadOpenClosedWestDoorEvent(room);
        }
        public static void AllEnemiesDeadOpenSouthDoor(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadOpenClosedSouthDoorEvent(room);
        }
        public static void AllEnemiesDeadOpenNorthDoor(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadOpenClosedNorthDoorEvent(room);
        }
        public static void CloseStartingDoorAfterStart(Room room, LevelEvent levelEvent)
        {
            new CloseStartingDoorAfterStartEvent(room);
        }
        public static void AllEnemiesDeadHeartContainerDrop(Room room, LevelEvent levelEvent)
        {
            new AllEnemiesDeadHeartContainerDropEvent(LevelUtilities.CalculatePositionWallOffset(room, levelEvent));
        }
    }
}
