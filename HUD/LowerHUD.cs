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
        private List<AnimatedSprite> Keys;
        private List<AnimatedSprite> Boombs;
        private List<AnimatedSprite> Life;

        private Vector2 TempPos;
        private Vector2 LowerHUDBasePos;
        private Vector2 LevelIndicatorPos;
        private Vector2 LevelNumberPos;
        private Vector2 WeponAPos;
        private Vector2 WeponBPos;
        private Vector2 RubiesPos;
        private Vector2 KeysPos;
        private Vector2 BoombsPos;
        private Vector2 LifePos;

        private int Level;
        private int RubiesCount;
        private int KeysCount;
        private int BoombsCount;
        private int CurrentHealth;
        private int MaxHealth;

        public LowerHUD(Game1 game)
        {
            this.game = game;

            letterFactory = LetterFactory.GetInstance();
            spriteFactory = SpriteFactory.getInstance();
        }

        public void LoadContent()
        {
            // The below values are for test now, should be changed later
            Level = 2;
            RubiesCount = 24;
            KeysCount = 8;
            BoombsCount = 24;
            CurrentHealth = 17;
            MaxHealth = 32;

            LowerHUDBase = spriteFactory.CreateLowerHUDSprite();
            LevelIndicator = spriteFactory.CreateLevelHUDSprite();
            LevelNumber = letterFactory.GetLetterSprite(Level);
            // The wepons below should be able to change later. These are test only.
            WeponA = spriteFactory.CreateWoodenSwoardSprite();
            WeponB = spriteFactory.CreateWoodenBoomerangHUDSprite();
            Rubies = QuantityToSprite(RubiesCount);
            Keys = QuantityToSprite(KeysCount);
            Boombs = QuantityToSprite(BoombsCount);
            GetHealthSprite(CurrentHealth, MaxHealth);

            // The below position is for test now, should be changed to GameState.CameraController.HUDLocation later
            LowerHUDBasePos = GameState.CameraController.mainCamera.worldPos;
            LevelIndicatorPos = new Vector2(LowerHUDBasePos.X + 16 * scale, LowerHUDBasePos.Y + 8 * scale);
            LevelNumberPos = new Vector2(LevelIndicatorPos.X + 48 * scale, LevelIndicatorPos.Y);
            WeponAPos = new Vector2(LowerHUDBasePos.X + 152 * scale, LowerHUDBasePos.Y + 24 * scale);
            WeponBPos = new Vector2(LowerHUDBasePos.X + 128 * scale, LowerHUDBasePos.Y + 24 * scale);
            RubiesPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 16 * scale);
            KeysPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 32 * scale);
            BoombsPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 40 * scale);
            LifePos = new Vector2(LowerHUDBasePos.X + 176 * scale, LowerHUDBasePos.Y + 32 * scale);

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Show()
        {
            LoadContent();

            RegisterSprite(LowerHUDBase, LowerHUDBasePos);

            RegisterSprite(LevelIndicator, LevelIndicatorPos);
            RegisterSprite(LevelNumber, LevelNumberPos);
            
            RegisterSprite(WeponA, WeponAPos);
            RegisterSprite(WeponB, WeponBPos);

            RegisterListSprite(Rubies, RubiesPos);

            RegisterListSprite(Keys, KeysPos);

            RegisterListSprite(Boombs, BoombsPos);

            RegisterLifeSprite(Life, LifePos);
            
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

        // My current thought on the health is the health of link will be an integer. Since the max health is 16 hearts, the MaxHealth will be 32 and must be divisible by 2.
        // The CurrentHealth will be range in 0 to MaxHealth. If the CurrentHealth cannot be divisible by 2. That's mean there is a half heart. 

        public void GetHealthSprite(int currentHealth, int maxHealth)
        {
            Life = new List<AnimatedSprite>();
            for (int i = 0; i < 16; i++)
            {
                Life.Add(letterFactory.GetBlankSprite());
            }

            for (int i = 0; i < maxHealth / 2; i++)
            {
                Life[i] = spriteFactory.CreateHeartSprite(0);
            }

            if (currentHealth % 2 != 0)
            {
                for (int i = 0; i < currentHealth / 2; i++)
                {
                    Life[i] = spriteFactory.CreateHeartSprite(2);
                }
                Life[currentHealth / 2] = spriteFactory.CreateHeartSprite(1);
            }
            else
            {
                for (int i = 0; i < currentHealth / 2; i++)
                {
                    Life[i] = spriteFactory.CreateHeartSprite(2);
                }
            }
        }

        public void UpdateMaxHealth(int maxHealth)
        {
            MaxHealth = maxHealth;
            for (int i = 0; i < maxHealth / 2; i++)
            {
                Life[i] = spriteFactory.CreateHeartSprite(0);
            }
        }

        public void UpdateCurrentHealth(int currentHealth)
        {
            CurrentHealth = currentHealth;
            if (currentHealth % 2 != 0)
            {
                for (int i = 0; i < currentHealth / 2; i++)
                {
                    Life[i] = spriteFactory.CreateHeartSprite(2);
                }
                Life[currentHealth / 2] = spriteFactory.CreateHeartSprite(1);
            }
            else
            {
                for (int i = 0; i < currentHealth / 2; i++)
                {
                    Life[i] = spriteFactory.CreateHeartSprite(2);
                }
            }
        }

        public void RegisterSprite(AnimatedSprite sprite, Vector2 pos)
        {
            sprite.RegisterSprite();
            sprite.UpdatePos(pos);
        }

        public void RegisterListSprite(List<AnimatedSprite> spriteList, Vector2 pos)
        {
            Vector2 tempPos = pos;
            foreach (AnimatedSprite sprite in spriteList)
            {
                sprite.RegisterSprite();
                sprite.UpdatePos(TempPos);
                TempPos.X += 8 * scale;
            }
        }

        public void RegisterLifeSprite(List<AnimatedSprite> spriteList, Vector2 pos)
        {
            Vector2 tempPos = pos;
            int index = 0;
            foreach (AnimatedSprite sprite in spriteList)
            {
                sprite.RegisterSprite();
                if (index == 8)
                {
                    tempPos = new Vector2(pos.X, pos.Y + 8 * scale);
                }
                sprite.UpdatePos(tempPos);
                tempPos.X += 8 * scale;
                index++;
            }
        }

        public void UnregisterListSprite(List<AnimatedSprite> spriteList)
        {
            foreach (AnimatedSprite sprite in spriteList)
            {
                sprite.UnregisterSprite();
            }
        }

        public void UpdateRubies(int rubies)
        {
            UnregisterListSprite(Rubies);
            RubiesCount = rubies;
            Rubies = QuantityToSprite(RubiesCount);
        }

        public void UpdateKeys(int keys)
        {
            KeysCount = keys;
            Keys = QuantityToSprite(KeysCount);
        }

        public void UpdateBoombs(int boombs)
        {
            BoombsCount = boombs;
            Boombs = QuantityToSprite(BoombsCount);
        }
    }
}
