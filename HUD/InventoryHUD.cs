using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class InventoryHUD : IHUD
    {
        private const int scale = 4;

        Game1 game;

        private SpriteFactory spriteFactory;
        private LetterFactory letterFactory;

        private AnimatedSprite InventoryHUDBase;
        private AnimatedSprite SelectedItem;
        private Dictionary<string, AnimatedSprite> ItemsInFrame;
        private Dictionary<string, AnimatedSprite> ItemsAboveFrame;
        private AnimatedSprite Selector;

        private Vector2 InventoryHUDBasePos;
        private Vector2 SelectedItemPos;
        private Dictionary<string, Vector2> InventoryItemsPosDict;
        private Dictionary<string, Vector2> InventoryItemsAbovePosDict;
        private Vector2 SelectorInitPos;
        private Vector2 SelectorPos;
        private Dictionary<string, bool> SelectorPosDic;

        private Dictionary<string, bool> InventoryInFrameUnlock;
        private Dictionary<string, bool> InventoryAboveFrameUnlock;



        public InventoryHUD(Game1 game)
        {
            this.game = game;

            spriteFactory = SpriteFactory.getInstance();
            letterFactory = LetterFactory.GetInstance();
        }

        public void LoadContent()
        {
            InventoryHUDBase = spriteFactory.CreateInventoryHUDSprite();
            // Should be able to change to the selected item, this is only for test now
            SelectedItem = spriteFactory.CreateWoodenBoomerangHUDSprite();
            CreateItemInFramesSprites();
            CreateItemAboveFramesSprites();
            Selector = spriteFactory.CreateSelectorSprite();

            InventoryHUDBasePos = GameState.CameraController.mainCamera.worldPos;
            SelectedItemPos = new Vector2(InventoryHUDBasePos.X + 68 * scale, InventoryHUDBasePos.Y + 48 * scale);
            CreateItemInFramesPos();
            CreateItemAboveFramesPos();
            SelectorInitPos = new Vector2(InventoryHUDBasePos.X + 128 * scale, InventoryHUDBasePos.Y + 48 * scale);
            SelectorPos = SelectorInitPos; // SelectorPos will change when player select different item, this is only for test now

            CreateInventoryInUnlock();
            CreateInventoryAboveUnlock();
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Show()
        {
            LoadContent();

            RegisterSprite(InventoryHUDBase, InventoryHUDBasePos);

            RegisterSprite(SelectedItem, SelectedItemPos);

            RegisterDictionarySprite(ItemsInFrame, InventoryInFrameUnlock, InventoryItemsPosDict);

            RegisterDictionarySprite(ItemsAboveFrame, InventoryAboveFrameUnlock, InventoryItemsAbovePosDict);

            Selector.RegisterSprite();
            Selector.UpdatePos(SelectorPos);
        }

        public void CreateItemInFramesSprites()
        {
            ItemsInFrame = new Dictionary<string, AnimatedSprite>
            {
                { "boomerang", spriteFactory.CreateWoodenBoomerangHUDSprite() },
                { "bomb", spriteFactory.CreateBombSprite() },
                { "arrow", spriteFactory.CreateWoodenArrowSprtie() },
                { "bow", spriteFactory.CreateWoodenBowSprite() },
                { "candle", spriteFactory.CreateBlueCandleSprite() },
                { "rod", spriteFactory.CreateRodSprite() },
                { "food", spriteFactory.CreateFoodSprite() },
                { "potion", spriteFactory.CreateBluePotionSprite() },
                { "wand", spriteFactory.CreateWandSprite() }
            };
        }

        public void CreateItemAboveFramesSprites()
        {
            ItemsAboveFrame = new Dictionary<string, AnimatedSprite>
            {
                { "bridge", spriteFactory.CreateBridgeSprite() },
                { "book", spriteFactory.CreateBookSprite() },
                { "ring", spriteFactory.CreateRingSprite() },
                { "ladder", spriteFactory.CreateHUDLadderSprite() },
                { "dragonKey", spriteFactory.CreateDargonKeySprite() },
                { "bread", spriteFactory.CreateBreadSprite() }
            };
        }

        public void CreateItemInFramesPos()
        {
            Vector2 basePos = InventoryHUDBasePos;
            InventoryItemsPosDict = new Dictionary<string, Vector2>
            {
                { "boomerang", new Vector2(basePos.X + 132 * scale, basePos.Y + 48 * scale) },
                { "bomb", new Vector2(basePos.X + 156 * scale, basePos.Y + 48 * scale) },
                { "arrow", new Vector2(basePos.X + 176 * scale, basePos.Y + 48 * scale) },
                { "bow", new Vector2(basePos.X + 184 * scale, basePos.Y + 48 * scale) },
                { "candle", new Vector2(basePos.X + 204 * scale, basePos.Y + 48 * scale) },
                { "rod", new Vector2(basePos.X + 132 * scale, basePos.Y + 64 * scale) },
                { "food", new Vector2(basePos.X + 156 * scale, basePos.Y + 64 * scale) },
                { "potion", new Vector2(basePos.X + 180 * scale, basePos.Y + 64 * scale) },
                { "wand", new Vector2(basePos.X + 204 * scale, basePos.Y + 64 * scale) }
            };
        }

        public void CreateItemAboveFramesPos()
        {
            Vector2 basePos = InventoryHUDBasePos;
            InventoryItemsAbovePosDict = new Dictionary<string, Vector2>
            {
                { "bridge", new Vector2(basePos.X + 128 * scale, basePos.Y + 24 * scale) },
                { "book", new Vector2(basePos.X + 152 * scale, basePos.Y + 24 * scale) },
                { "ring", new Vector2(basePos.X + 164 * scale, basePos.Y + 24 * scale) },
                { "ladder", new Vector2(basePos.X + 176 * scale, basePos.Y + 24 * scale) },
                { "dragonKey", new Vector2(basePos.X + 196 * scale, basePos.Y + 24 * scale) },
                { "bread", new Vector2(basePos.X + 208 * scale, basePos.Y + 24 * scale) }
            };
        }

        // Set all to true for test
        public void CreateInventoryInUnlock()
        {
            InventoryInFrameUnlock = new Dictionary<string, bool>
            {
                { "boomerang", true },
                { "bomb", true },
                { "arrow", true },
                { "bow", true },
                { "candle", true },
                { "rod", true },
                { "food", true },
                { "potion", true },
                { "wand", true }
            };
        }

        public void CreateInventoryAboveUnlock()
        {
            InventoryAboveFrameUnlock = new Dictionary<string, bool>
            {
                { "bridge", true },
                { "book", true },
                { "ring", true },
                { "ladder", true },
                { "dragonKey", true },
                { "bread", true }
            };
        }

        public void RegisterSprite(AnimatedSprite sprite, Vector2 pos)
        {
            sprite.RegisterSprite();
            sprite.UpdatePos(pos);
        }

        public void RegisterDictionarySprite(Dictionary<string, AnimatedSprite> spriteList, Dictionary<string, bool> unlock, Dictionary<string, Vector2> posList)
        {
            foreach (KeyValuePair<string, AnimatedSprite> sprite in spriteList)
            {
                if (unlock[sprite.Key])
                {
                    sprite.Value.RegisterSprite();
                    sprite.Value.UpdatePos(posList[sprite.Key]);
                }
            }
        }

        public void UnRegisterDictionarySprite(Dictionary<string, AnimatedSprite> spriteList, Dictionary<string, bool> unlock)
        {
            foreach (KeyValuePair<string, AnimatedSprite> sprite in spriteList)
            {
                if (!unlock[sprite.Key])
                {
                    sprite.Value.UnregisterSprite();
                }
            }
        }

        public void UpdateInventoryInUnlock(string item)
        {
            InventoryInFrameUnlock[item] = true;
        }

        public void UpdateInventoryAboveUnlock(string item)
        {
            InventoryAboveFrameUnlock[item] = true;
        }   
    }
}
