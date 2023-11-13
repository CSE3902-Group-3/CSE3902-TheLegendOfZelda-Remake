using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class MapHUD : IHUD
    {
        private const int scale = 4;
        private const int mapSize = 64;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;

        private AnimatedSprite MapHUDBase;
        private AnimatedSprite Map;
        private AnimatedSprite Compass;

        private Vector2 MapHUDBasePos;
        private Vector2 MapSpritePos;
        private Vector2 CompassPos;
        private Vector2 MapBasePos;

        private Dictionary<AnimatedSprite, Vector2> MapElement;

        private bool MapUnlock;
        private bool CompassUnlock;

        private List<int> ElementList = new List<int>()
        {
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1,  4, -1, -1, -1, -1,
            -1, -1, -1, 12, -1,  4, -1, -1,
            -1,  1,  5, 11,  3, 10, -1, -1,
            -1, -1,  8,  7, -1, -1, -1, -1,
            -1, -1, -1,  4, -1, -1, -1, -1,
            -1, -1,  1, 15,  2, -1, -1, -1
        };

        public MapHUD()
        {
            spriteFactory = SpriteFactory.getInstance();
            letterFactory = LetterFactory.GetInstance();
        }

        public void LoadContent()
        {
            MapHUDBase = spriteFactory.CreateMapHUDSprite();
            Map = spriteFactory.CreateMapSprite();
            Compass = spriteFactory.CreateCompassSprite();

            // Only for the test
            MapHUDBasePos = GameState.CameraController.HUDLocation;
            MapSpritePos = new Vector2(MapHUDBasePos.X + 48 * scale, MapHUDBasePos.Y + 24 * scale);
            CompassPos = new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 64 * scale);
            MapBasePos = new Vector2(MapHUDBasePos.X + 128 * scale, MapHUDBasePos.Y + 8 * scale);

            CreateMapElement();

            // The below values are for test now, should be changed later
            MapUnlock = true;
            CompassUnlock = true;
        }

        public void Update(GameTime gametime)
        {

        }

        public void Show()
        {
            LoadContent();

            RegisterSprite(MapHUDBase, MapHUDBasePos);

            RegisterMapCompassSprite(Map, MapSpritePos, MapUnlock);

            RegisterMapCompassSprite(Compass, CompassPos, CompassUnlock);

            RegisterMap();
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

        public void UpdateMapUnlock(bool unlock)
        {
            MapUnlock = unlock;
        }

        public void UpdateCompassUnlock(bool unlock)
        {
            CompassUnlock = unlock;
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
