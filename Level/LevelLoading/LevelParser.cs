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
    public class LevelParser
    {
        public static RoomList Parse(string levelFileName)
        {
            // Read JSON file and store information in RoomList
            try
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "Level", "Levels", levelFileName);
                string jsonText = File.ReadAllText(filepath);
                RoomList roomList = JsonSerializer.Deserialize<RoomList>(jsonText);
                return roomList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("--LEVEL PARSING ISSUE--");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
