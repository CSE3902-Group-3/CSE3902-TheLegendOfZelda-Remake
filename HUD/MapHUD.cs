using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MapHUD : IHUD
    {
        private static MapHUD instance;

        private const int scale = 4;
        private const int mapSize = 64;
        private int CurrentRoom;
        private int Level;

        private SpriteFactory spriteFactory;
        private HUDMapElement mapElement;
        
        private Inventory inventory;
        private Map map;
        private Compass compass;

        private AnimatedSprite MapHUDBase;
        private AnimatedSprite Map;
        private AnimatedSprite Compass;
        private AnimatedSprite LocationIndicator;

        private Vector2 MapHUDBasePos;
        private Vector2 MapSpritePos;
        private Vector2 CompassPos;
        private Vector2 MapBasePos;

        private Dictionary<AnimatedSprite, Vector2> MapElement;
        private Dictionary<int, Vector2> IndicatorPosDic;

        public bool MapUnlock;
        public bool CompassUnlock;

        private List<int> ElementList;

        public MapHUD()
        {
            spriteFactory = SpriteFactory.getInstance();
            mapElement = HUDMapElement.GetInstance();
            inventory = Inventory.getInstance();

            GetLevel();

            map = new Map(Vector2.Zero);
            compass = new Compass(Vector2.Zero);

            MapHUDBase = spriteFactory.CreateMapHUDBaseSprite();
            Map = spriteFactory.CreateHUDMapSprite();
            Compass = spriteFactory.CreateHUDCompassSprite();
            LocationIndicator = spriteFactory.CreateMapIndicatorSprite();

            MapHUDBasePos = new Vector2(GameState.CameraController.ItemMenuLocation.X, GameState.CameraController.ItemMenuLocation.Y + 87 * scale);
            MapSpritePos = new Vector2(MapHUDBasePos.X + 48 * scale, MapHUDBasePos.Y + 24 * scale);
            CompassPos = new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 64 * scale);
            MapBasePos = new Vector2(MapHUDBasePos.X + 128 * scale, MapHUDBasePos.Y + 8 * scale);

            ElementList = mapElement.GetMapList(Level);
            IndicatorPosDic = mapElement.GetMapIndicator(Level);
            CreateMapElement();

            MapUnlock = false;
            CompassUnlock = false;
        }

        public static MapHUD GetInstance()
        {
            if (instance == null)
                instance = new MapHUD();

            return instance;
        }

        public void Update(GameTime gametime)
        {
            GetLevel();
            UpdateMapUnlock();
            UpdateCompassUnlock();
            RegisterIndicatorSprite(CompassUnlock);
        }

        public void Show()
        {
            RegisterSprite(MapHUDBase, MapHUDBasePos);
            RegisterMap();
        }

        public void GetLevel()
        {
            if (LevelManager.CurrentLevel == 0)
            {
                Level = 1;
            }
            else
            {
                Level = LevelManager.CurrentLevel;
            }
        }

        public void CreateMapElement()
        {
            MapElement = new Dictionary<AnimatedSprite, Vector2>();
            for (int i = 0; i < mapSize; i++)
            {
                AnimatedSprite element = spriteFactory.CreateMapElement(ElementList[i]);
                Vector2 pos = new Vector2(MapBasePos.X + (i % 8) * 8 * scale, MapBasePos.Y + (i / 8) * 8 * scale);

                MapElement.Add(element, pos);
            }
        }

        public void UpdateMapUnlock()
        {
            int newCount = inventory.GetQuantity(map);
            if (newCount > 0)
            {
                MapUnlock = true;
                RegisterSprite(Map, MapSpritePos);
            }
            else
            {
                MapUnlock = false;
                Map.UnregisterSprite();
            }
        }

        public void UpdateCompassUnlock()
        {
            int newCount = inventory.GetQuantity(compass);
            if (newCount > 0)
            {
                CompassUnlock = true;
                RegisterSprite(Compass, CompassPos);
            }
            else
            {
                CompassUnlock = false;
                Compass.UnregisterSprite();
            }
        }

        public void RegisterIndicatorSprite(bool unlock)
        {
            CurrentRoom = LevelManager.CurrentRoom;
            if (unlock)
            {
                LocationIndicator.RegisterSprite();
                LocationIndicator.UpdatePos(IndicatorPosDic[CurrentRoom]);
            }
            else
            {
                LocationIndicator.UnregisterSprite();
            }
        }

        public void RegisterSprite(AnimatedSprite sprite, Vector2 pos)
        {
            sprite.RegisterSprite();
            sprite.UpdatePos(pos);
        }

        public void RegisterMapCompassSprite(AnimatedSprite sprite, Vector2 pos, bool unlock)
        {
            if (unlock)
            {
                sprite.RegisterSprite();
                sprite.UpdatePos(pos);
            }
            else
            {
                sprite.UnregisterSprite();
            }
        }

        public void RegisterMap()
        {
            foreach (KeyValuePair<AnimatedSprite, Vector2> element in MapElement)
            {
                element.Key.RegisterSprite();
                element.Key.UpdatePos(element.Value);
            }
        }

    }
}
