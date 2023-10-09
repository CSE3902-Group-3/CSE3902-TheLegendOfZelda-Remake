using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LegendOfZelda
{
    internal class Level
    {
        private RoomList RoomList;
        public List<IUpdateable> LevelUpdateableList { get; set; }
        public List<IDrawable> LevelDrawableList { get; set; }
        public int CurrentRoom;
        public static int Scale = 128;
        private BlockLamda BlockLamda = BlockLamda.GetInstance();
        public Level(string levelFileName)
        {
            // Read JSON file and store information in RoomList
            try
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Levels\\" + levelFileName);
                string jsonText = File.ReadAllText(filepath);
                RoomList = JsonSerializer.Deserialize<RoomList>(jsonText);
            } 
            catch (Exception ex)
            {
                Console.WriteLine("--LEVEL PARSING ISSUE--");
                Console.WriteLine(ex.Message);
            }
        }
        public Boolean NavigateToRoom(int roomNumber) 
        {
            if (roomNumber < 0 || roomNumber >= RoomList.Rooms.Count) 
            { 
                return false;
            }

            foreach (MapElement mapElement in RoomList.Rooms[roomNumber].MapElements)
            {
                ProcessMapElement(mapElement);
            }

            return true;
        }
        public Boolean NavigateNorth() 
        {
            return true;
        }
        public Boolean NavigateEast() 
        {
            return true;
        }
        public Boolean NavigateSouth() 
        {
            return true;
        }
        public Boolean NavigateWest() 
        {
            return true;
        }
        private void ProcessMapElement(MapElement mapElement)
        {
            switch (mapElement.ElementType)
            {
                case "Block":
                    BlockLamda.BlockFunctionArray[mapElement.ElementValue](mapElement);
                    break;
                case "Item":
                    
                    break;
                case "Enemy":

                    break;
                default:
                    Console.WriteLine("INVALID MAP ELEMENT TYPE: " + mapElement.ElementType);
                    break;
            }
        }
    }
}
