using System;
using System.Collections.Generic;
using System.Diagnostics;
using static LegendOfZelda.SimpleEnemyStateMachine;

namespace LegendOfZelda
{
    public class ReadConfig
    {
        private IniFile iniFile;

        public Dictionary<string, float> GameConfig;
        public ReadConfig(string iniFilePath)
        {
            iniFile = new IniFile(iniFilePath);
            Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Debug.WriteLine("Reading config file: " + iniFilePath);

            GameConfig = new Dictionary<string, float>
            {
                { "Link.Speed", 5.0f },
                { "Link.Health", 6.0f },
                { "Game.Difficulty", 1.0f }
            };

            GetLinkSpeed();
            GetLinkHealth();
            GetDifficulty();
        }

        public void GetLinkSpeed()
        {
            string section = "Link";
            string key = "Speed";

            if (iniFile.KeyExists(key, section))
            {
                string linkSpeed = iniFile.Read(key, section);

                if (int.TryParse(linkSpeed, out int speed))
                {
                    // Successfully parsed, return the speed.
                    GameConfig["Link.Speed"] = speed;
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's speed. Check the INI file format.");
                }
            }
        }

        public void GetLinkHealth()
        {
            string section = "Link";
            string key = "Health";

            if (iniFile.KeyExists(key, section))
            {
                string linkHealth = iniFile.Read(key, section);

                if (int.TryParse(linkHealth, out int health))
                {
                    // Successfully parsed, return the health.
                    GameConfig["Link.Health"] = health;
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's health. Check the INI file format.");
                }
            }
        }

        public void GetDifficulty()
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
                    GameConfig["Game.Difficulty"] = difficultyMultiplier;
                }
                else
                {
                    Debug.WriteLine("Invalid difficulty level. Check the INI file format.");
                }
            }
        }
    }
}
