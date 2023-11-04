using LegendOfZelda.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LowerHUD : IHUD
    {
        private const int scale = 4;

        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;

        private AnimatedSprite LowerHUDBase;
        private AnimatedSprite LevelIndicator;
        private AnimatedSprite LevelNumber;
        private AnimatedSprite WeponA;
        private AnimatedSprite WeponB;
        private List<AnimatedSprite> Rubies;

        private Vector2 LowerHUDBasePos;
        private Vector2 LevelIndicatorPos;
        private Vector2 LevelNumberPos;
        private Vector2 WeponAPos;
        private Vector2 RubiesPos;

        private int Level;
        private int RubiesCount;

        public LowerHUD(Game1 game)
        {
            this.game = game;

            letterFactory = LetterFactory.GetInstance();
            spriteFactory = SpriteFactory.getInstance();
        }

        public void LoadContent()
        {
            Level = 2;
            RubiesCount = 24;

            LowerHUDBase = spriteFactory.CreateLowerHUDSprite();
            LevelIndicator = spriteFactory.CreateLevelHUDSprite();
            LevelNumber = letterFactory.GetLetterSprite(Level);
            WeponA = spriteFactory.CreateWoodenSwoardSprite();
            Rubies = QuantityToSprite(RubiesCount);

            // The below position is for test now, should be changed to GameState.CameraController.HUDLocation later
            LowerHUDBasePos = GameState.CameraController.mainCamera.worldPos;
            LevelIndicatorPos = new Vector2(LowerHUDBasePos.X + 16 * scale, LowerHUDBasePos.Y + 8 * scale);
            LevelNumberPos = new Vector2(LevelIndicatorPos.X + 48 * scale, LevelIndicatorPos.Y);
            WeponAPos = new Vector2(LowerHUDBasePos.X + 152 * scale, LowerHUDBasePos.Y + 24 * scale);
            RubiesPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 16 * scale);

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Show()
        {
            LoadContent();

            LowerHUDBase.RegisterSprite();
            LowerHUDBase.UpdatePos(LowerHUDBasePos);

            LevelIndicator.RegisterSprite();
            LevelIndicator.UpdatePos(LevelIndicatorPos);
            LevelNumber.RegisterSprite();
            LevelNumber.UpdatePos(LevelNumberPos);
            
            WeponA.RegisterSprite();
            WeponA.UpdatePos(WeponAPos);

            foreach (AnimatedSprite sprite in Rubies)
            {
                sprite.RegisterSprite();
                sprite.UpdatePos(RubiesPos);
                RubiesPos.X += 8 * scale;
            }
        }

        public List<AnimatedSprite> QuantityToSprite(int quantitiy)
        {
            List<AnimatedSprite> spriteList = new List<AnimatedSprite>();

            spriteList.Add(letterFactory.GetLetterSprite('X', 0));
            if (quantitiy < 10)
            {
                spriteList.Add(letterFactory.GetLetterSprite(quantitiy));
                spriteList.Add(letterFactory.GetBlankSprite());
            }
            else
            {
                spriteList.Add(letterFactory.GetLetterSprite(quantitiy / 10));
                spriteList.Add(letterFactory.GetLetterSprite(quantitiy % 10));
            }

            return spriteList;
        }
    }
}
