using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    // Level class with the functionality of reading the level file and processing its contents
    internal class Level
    {
        private static BlockLamda BlockLamda = BlockLamda.GetInstance();
        private static ItemLamda ItemLamda = ItemLamda.GetInstance();
        private static EnemyLamda EnemyLamda = EnemyLamda.GetInstance();
        private static LevelMaster LevelMaster = LevelMaster.GetInstance();

        public RoomList RoomList { get; }
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
        public Level(string levelFileName)
        {
            // Read JSON file and store information in RoomList
            try
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Level\\Levels\\" + levelFileName);
                string jsonText = File.ReadAllText(filepath);
                RoomList = JsonSerializer.Deserialize<RoomList>(jsonText);
                for (int i = 0; i < RoomList.Rooms.Count; i++)
                {
                    LevelMaster.CurrentRoom = i;
                    foreach (MapElement mapElement in RoomList.Rooms[i].MapElements)
                    {
                        ProcessMapElement(mapElement);
                    }
                }
                LevelMaster.CurrentRoom = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("--LEVEL PARSING ISSUE--");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
