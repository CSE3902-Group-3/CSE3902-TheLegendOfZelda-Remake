using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class ReadConfig
    {
        private IniFile iniFile;

        public ReadConfig(string iniFilePath)
        {
            iniFile = new IniFile(iniFilePath);
            Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Debug.WriteLine("Reading config file: " + iniFilePath);
        }

        public int GetLinkSpeed()
        {
            string section = "Link";
            string key = "Speed";

            if (iniFile.KeyExists(key, section))
            {
                string linkSpeed = iniFile.Read(key, section);

                if (int.TryParse(linkSpeed, out int speed))
                {
                    // Successfully parsed, return the speed.
                    return speed;
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's speed. Check the INI file format.");
                }
            }
            else
            {
                // The key or section doesn't exist, return a default value of 5.
                Debug.WriteLine("Link's speed key or section not found. Using default value: 5");
                return 5;
            }

            // Default case: return 0 if there's an error.
            return 0;
        }

        public int GetLinkHealth()
        {
            string section = "Link";
            string key = "Health";

            if (iniFile.KeyExists(key, section))
            {
                string linkHealth = iniFile.Read(key, section);

                if (int.TryParse(linkHealth, out int health))
                {
                    // Successfully parsed, return the speed.
                    return health;
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's health. Check the INI file format.");
                }
            }
            else
            {
                // The key or section doesn't exist, return a default value of 5.
                Debug.WriteLine("Link's health key or section not found. Using default value: 5");
                return 5;
            }

            // Default case: return 0 if there's an error.
            return 0;
        }

        public float GetDifficulty()
        {
            string section = "Enemies";
            string key = "Difficulty";

            if (iniFile.KeyExists(key, section))
            {
                string difficultyString = iniFile.Read(key, section);

                // Map difficulty levels to float values
                Dictionary<string, float> difficultyMap = new Dictionary<string, float>
                {
                    { "Easy", 0.5f },
                    { "Medium", 1.0f },
                    { "Hard", 2.0f }
                };

                if (difficultyMap.TryGetValue(difficultyString, out float difficultyMultiplier))
                {
                    // Successfully mapped, return the difficulty multiplier.
                    return difficultyMultiplier;
                }
                else
                {
                    Debug.WriteLine("Invalid difficulty level. Check the INI file format.");
                }
            }
            else
            {
                // The key or section doesn't exist, return a default value of 1.0 (Medium).
                Debug.WriteLine("Difficulty key or section not found. Using default value: 1.0 (Medium)");
                return 1.0f;
            }

            // Default case: return 0.0 if there's an error.
            return 0.0f;
        }
    }
}
