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

        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;

        private AnimatedSprite MapHUDBase;
        private AnimatedSprite Map;
        private AnimatedSprite Compass;

        private Vector2 MapHUDBasePos;
        private Vector2 MapPos;
        private Vector2 CompassPos;

        private bool MapUnlock;
        private bool CompassUnlock;

        public MapHUD(Game1 game)
        {
            this.game = game;

            spriteFactory = SpriteFactory.getInstance();
            letterFactory = LetterFactory.GetInstance();
        }

        public void LoadContent()
        {
            MapHUDBase = spriteFactory.CreateMapHUDSprite();
            Map = spriteFactory.CreateMapSprite();
            Compass = spriteFactory.CreateCompassSprite();

            MapHUDBasePos = GameState.CameraController.mainCamera.worldPos;
            MapPos = new Vector2(MapHUDBasePos.X + 48 * scale, MapHUDBasePos.Y + 24 * scale);
            CompassPos = new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 64 * scale);

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

            MapHUDBase.RegisterSprite();
            MapHUDBase.UpdatePos(MapHUDBasePos);

            switch (MapUnlock)
            {
                case true:
                    Map.RegisterSprite();
                    Map.UpdatePos(MapPos);
                    break;
                case false:
                    Map.UnregisterSprite();
                    break;
            }

            switch (CompassUnlock)
            {
                case true:
                    Compass.RegisterSprite();
                    Compass.UpdatePos(CompassPos);
                    break;
                case false:
                    Compass.UnregisterSprite();
                    break;
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
    }
}
