using System;
using System.Collections.Generic;
using System.Diagnostics;
using static LegendOfZelda.EnemyStateMachine;

namespace LegendOfZelda
{
    public class ReadConfig
    {
        // number of config variables in the ini file
        private const int numConfig = 5;

        private IniFile iniFile;
        private delegate void anonFunc();
        private anonFunc[] anonFuncs = new anonFunc[numConfig];

        public Dictionary<string, string> GameConfig;
        public ReadConfig(string iniFilePath)
        {
            iniFile = new IniFile(iniFilePath);
            Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());
            Debug.WriteLine("Reading config file: " + iniFilePath);

            GameConfig = new Dictionary<string, string>
            {
                { "Link.Speed", "5.0" },
                { "Link.Health", "6.0" },
                { "Link.ProjectileSpawnCooldown", "3.0" },
                { "Game.Difficulty", "1.0" },
                { "Game.Level", "level1.json" }
            };

            anonFuncs[0] = GetLinkSpeed;
            anonFuncs[1] = GetLinkHealth;
            anonFuncs[2] = GetLinkProjectileSpawnCooldown;
            anonFuncs[3] = GetDifficulty;
            anonFuncs[4] = GetStartLevel;

            foreach (var func in anonFuncs)
            {
                func?.Invoke();
            }
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
                    GameConfig["Link.Speed"] = speed.ToString();
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's speed. Using default. Check INI file if you meant to set it.");
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
                    GameConfig["Link.Health"] = health.ToString();
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's health. Using default. Check INI file if you meant to set it.");
                }
            }
        }

        public void GetLinkProjectileSpawnCooldown()
        {
            string section = "Link";
            string key = "ProjectileSpawnCooldown";

            if (iniFile.KeyExists(key, section))
            {
                string linkProjectileSpawnCooldown = iniFile.Read(key, section);

                if (int.TryParse(linkProjectileSpawnCooldown, out int cooldown))
                {
                    // Successfully parsed, return the health.
                    GameConfig["Link.ProjectileSpawnCooldown"] = cooldown.ToString();
                }
                else
                {
                    Debug.WriteLine("Failed to parse Link's projectile spawn cooldown time. Using default. Check INI file if you meant to set it.");
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
                    GameConfig["Game.Difficulty"] = difficultyMultiplier.ToString();
                }
                else
                {
                    Debug.WriteLine("Invalid difficulty level. Using default. Check INI file if you meant to set it.");
                }
            }
        }

        public void GetStartLevel()
        {
            string section = "Game";
            string key = "Level";

            if (iniFile.KeyExists(key, section))
            {
                string levelString = iniFile.Read(key, section);

                // Map difficulty levels to float values
                Dictionary<string, string> levelMap = new Dictionary<string, string>
                {
                    { "1", "1" },
                    { "2", "2" }
                };

                if (levelMap.TryGetValue(levelString, out string level))
                {
                    // Successfully mapped, return the difficulty multiplier.
                    GameConfig["Game.Level"] = level;
                }
                else
                {
                    Debug.WriteLine("Invalid start level. Using default. Check INI file if you meant to set it.");
                }
            }
        }
    }
}
