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
        private static LowerHUD instance;

        private const int scale = 4;
        private const int mapSize = 32;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;

        private Inventory inventory;
        private Link link;

        private AnimatedSprite LowerHUDBase;
        private AnimatedSprite LevelIndicator;
        private AnimatedSprite LevelNumber;
        private AnimatedSprite WeponA;
        private AnimatedSprite WeponB;
        private AnimatedSprite LocationIndicator;
        private List<AnimatedSprite> Rubies;
        private List<AnimatedSprite> Keys;
        private List<AnimatedSprite> Bombs;
        private List<AnimatedSprite> Life;

        private Vector2 LowerHUDBasePos;
        private Vector2 LevelIndicatorPos;
        private Vector2 LevelNumberPos;
        private Vector2 WeponAPos;
        private Vector2 WeponBPos;
        private Vector2 RubiesPos;
        private Vector2 KeysPos;
        private Vector2 BombsPos;
        private Vector2 LifePos;

        private Dictionary<AnimatedSprite, Vector2> MiniMap;

        private int Level;
        private int RubiesCount;
        private int KeysCount;
        private int BombsCount;
        private int CurrentHealth;
        private int MaxHealth;

        private List<int> ElementList = new List<int>()
        {
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1,  0,  2, -1,  1,  1, -1,
            -1,  0,  2,  2,  2,  0, -1, -1,
            -1, -1,  1,  2,  1, -1, -1, -1
        };


        public LowerHUD()
        {
            letterFactory = LetterFactory.GetInstance();
            spriteFactory = SpriteFactory.getInstance();

            inventory = Inventory.getInstance();
            link = GameState.Link;

            Level = 1;
            RubiesCount = inventory.GetQuantity(new OneRupee(Vector2.Zero));
            KeysCount = inventory.GetQuantity(new Key(Vector2.Zero));
            BombsCount = inventory.GetQuantity(new Bomb(Vector2.Zero));

            CurrentHealth = (int)(link.GetCurrentHP() * 2);
            MaxHealth = (int)(link.GetMaxHP() * 2);

            LowerHUDBase = spriteFactory.CreateLowerHUDSprite();
            LevelIndicator = spriteFactory.CreateLevelHUDSprite();
            LevelNumber = letterFactory.GetLetterSprite(Level);
            // The wepons below should be able to change later. These are test only.
            WeponA = spriteFactory.CreateWoodenSwoardSprite();
            WeponB = spriteFactory.CreateWoodenBoomerangHUDSprite();
            Rubies = QuantityToSprite(RubiesCount);
            Keys = QuantityToSprite(KeysCount);
            Bombs = QuantityToSprite(BombsCount);
            GetHealthSprite(CurrentHealth, MaxHealth);

            // The below position is for test now, should be changed to GameState.CameraController.HUDLocation later
            LowerHUDBasePos = GameState.CameraController.HUDLocation;
            LevelIndicatorPos = new Vector2(LowerHUDBasePos.X + 16 * scale, LowerHUDBasePos.Y + 8 * scale);
            LevelNumberPos = new Vector2(LevelIndicatorPos.X + 48 * scale, LevelIndicatorPos.Y);
            WeponAPos = new Vector2(LowerHUDBasePos.X + 152 * scale, LowerHUDBasePos.Y + 24 * scale);
            WeponBPos = new Vector2(LowerHUDBasePos.X + 128 * scale, LowerHUDBasePos.Y + 24 * scale);
            RubiesPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 16 * scale);
            KeysPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 32 * scale);
            BombsPos = new Vector2(LowerHUDBasePos.X + 96 * scale, LowerHUDBasePos.Y + 40 * scale);
            LifePos = new Vector2(LowerHUDBasePos.X + 176 * scale, LowerHUDBasePos.Y + 32 * scale);

            CreateMiniMap();
        }

        public static LowerHUD GetInstance()
        {
            if (instance == null)
                instance = new LowerHUD();
            return instance;
        }

        public void Update(GameTime gameTime)
        {
            UpdateRubies();
            UpdateKeys();
            UpdateBoombs();
            UpdateHealth();
        }

        public void Show()
        {
            RegisterSprite(LowerHUDBase, LowerHUDBasePos);

            RegisterSprite(LevelIndicator, LevelIndicatorPos);
            RegisterSprite(LevelNumber, LevelNumberPos);
            
            RegisterSprite(WeponA, WeponAPos);
            RegisterSprite(WeponB, WeponBPos);

            RegisterListSprite(Rubies, RubiesPos);

            RegisterListSprite(Keys, KeysPos);

            RegisterListSprite(Bombs, BombsPos);

            RegisterLifeSprite(Life, LifePos);

            RegisterMiniMapSprite();
            
        }

        public void CreateMiniMap()
        {
            Vector2 basePos = new Vector2(LevelIndicatorPos.X, LevelIndicatorPos.Y + 8 * scale);
            
            MiniMap = new Dictionary<AnimatedSprite, Vector2>();
            for (int i = 0; i < mapSize; i++)
            {
                AnimatedSprite tempSprite;
                Vector2 tempPos;
                int element = ElementList[i];
                if (element == -1)
                {
                    tempSprite = letterFactory.GetBlankSprite();
                }
                else
                {
                    tempSprite = spriteFactory.CreateMiniMapElement(element);
                }

                tempPos = new Vector2(basePos.X + (i % 8) * 8 * scale, basePos.Y + (i / 8) * 8 * scale);

                MiniMap.Add(tempSprite, tempPos);
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
                sprite.UpdatePos(tempPos);
                tempPos.X += 8 * scale;
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

        public void RegisterMiniMapSprite()
        {
            foreach (KeyValuePair<AnimatedSprite, Vector2> element in MiniMap)
            {
                element.Key.RegisterSprite();
                element.Key.UpdatePos(element.Value);
            }
        }

        public void UnRegisterListSprite(List<AnimatedSprite> spriteList)
        {
            foreach (AnimatedSprite sprite in spriteList)
            {
                sprite.UnregisterSprite();
            }
        }

        // Update Methods

        public void UpdateRubies()
        {
            if (RubiesCount != inventory.GetQuantity(new OneRupee(Vector2.Zero)))
            {
                RubiesCount = inventory.GetQuantity(new OneRupee(Vector2.Zero));
                UnRegisterListSprite(Rubies);
                Rubies = QuantityToSprite(RubiesCount);
                RegisterListSprite(Rubies, RubiesPos);
            }
        }

        public void UpdateKeys()
        {
            if (KeysCount != inventory.GetQuantity(new Key(Vector2.Zero)))
            {
                KeysCount = inventory.GetQuantity(new Key(Vector2.Zero));
                UnRegisterListSprite(Keys);
                Keys = QuantityToSprite(KeysCount);
                RegisterListSprite(Keys, KeysPos);
            }
        }

        public void UpdateBoombs()
        {
            if (BombsCount != inventory.GetQuantity(new Bomb(Vector2.Zero)))
            {
                BombsCount = inventory.GetQuantity(new Bomb(Vector2.Zero));
                UnRegisterListSprite(Bombs);
                Bombs = QuantityToSprite(BombsCount);
                RegisterListSprite(Bombs, BombsPos);
            }
        }

        public void UpdateHealth()
        {
            if (CurrentHealth != (int)(link.GetCurrentHP() * 2) || MaxHealth != (int)(link.GetMaxHP() * 2))
            {
                CurrentHealth = (int)(link.GetCurrentHP() * 2);
                MaxHealth = (int)(link.GetMaxHP() * 2);
                UnRegisterListSprite(Life);
                GetHealthSprite(CurrentHealth, MaxHealth);
            }
        }
    }
}
