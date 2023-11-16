using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Selector
    {
        private static Selector instance;

        private const int scale = 4;

        InventoryHUD inventoryHUD;

        private int SelectorIndex = 0;
        private int SelectorColorIndex = -1;

        private SpriteFactory spriteFactory;

        private AnimatedSprite SelectorSprite;
        private List<AnimatedSprite> SelectorSprites;

        private Vector2 BasePos;
        private Vector2 SelectorCurrPos;

        private struct SelectorPos
        {
            public Vector2 pos;
            public bool unlock;
        }

        private Dictionary<int, SelectorPos> PosDictionary;

        public Selector()
        {
            inventoryHUD = InventoryHUD.GetInstance();

            spriteFactory = SpriteFactory.getInstance();
            Vector2 InventoryHUDBasePos = GameState.CameraController.ItemMenuLocation;
            BasePos = new Vector2(InventoryHUDBasePos.X + 128 * scale, InventoryHUDBasePos.Y + 48 * scale);

            SelectorSprite = spriteFactory.CreateSelectorSprite();
            CreatePosDict();
            CreateSelectorSprites();
        }

        public static Selector GetInstance()
        {
            if (instance == null)
                instance = new Selector();

            return instance;
        }

        public void Update()
        {
            //UpdateColor();
            UpdateUnlock();
            if (inventoryHUD.GetUnlockCount() == 0)
                SelectorSprite.UnregisterSprite();
            else if (inventoryHUD.GetUnlockCount() == 1)
            {
                SelectorSprite.RegisterSprite();
                SelectorSprite.UpdatePos(PosDictionary[FindFirstUnlock()].pos);
            }
            else
                SelectorSprite.UpdatePos(PosDictionary[SelectorIndex].pos);
        }

        public void Show()
        {
            SelectorSprite.RegisterSprite();
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void CreateSelectorSprites()
        {
            SelectorSprites = new List<AnimatedSprite>();
            for (int i = 0; i < 2; i++)
            {
                SelectorSprites.Add(spriteFactory.CreateSelectorSprites(i));
            }
        }

        public void CreatePosDict()
        {
            PosDictionary = new Dictionary<int, SelectorPos>();
            List<bool> unLockList = inventoryHUD.GetUnlockList();
            for (int i = 0; i < 8; i++)
            {
                SelectorPos temp = new SelectorPos();
                if (i < 4)
                    temp.pos = new Vector2(BasePos.X + i * 24 * scale, BasePos.Y);
                else
                    temp.pos = new Vector2(BasePos.X + (i - 4) * 24 * scale, BasePos.Y + 16 * scale);
                if (i < 3)
                    temp.unlock = unLockList[i];
                else
                    temp.unlock = unLockList[i + 1];
                PosDictionary.Add(i, temp);
            }
        }

        private int FindFirstUnlock()
        {
            foreach (KeyValuePair<int, SelectorPos> entry in PosDictionary)
            {
                if (entry.Value.unlock)
                {
                    return entry.Key;
                }
            }

            return -1;
        }

        public void UpdateColor()
        {
            switch (SelectorColorIndex)
            {
                case 0:
                    SelectorSprite = SelectorSprites[0];
                    SelectorColorIndex = 1;
                    break;
                case 1:
                    SelectorSprite = SelectorSprites[1];
                    SelectorColorIndex = 0;
                    break;
            }
        }


        public void UpdateUnlock()
        {
            SelectorPos temp = new SelectorPos();
            for (int i = 0; i < 8; i++)
            {
                if (i < 3)
                {
                    temp = PosDictionary[i];
                    temp.unlock = inventoryHUD.GetUnlockList()[i];
                    PosDictionary[i] = temp;
                }
                else
                {
                    temp = PosDictionary[i];
                    temp.unlock = inventoryHUD.GetUnlockList()[i + 1];
                    PosDictionary[i] = temp;
                }
            }
        }

        public void SelectRight()
        {
            if (inventoryHUD.GetUnlockCount() < 2)
            {
                return;
            }
            if (SelectorIndex == 7)
                SelectorIndex = 0;
            else SelectorIndex++;
            while (!PosDictionary[SelectorIndex].unlock)
            {
                if (SelectorIndex == 7)
                    SelectorIndex = 0;
                else
                    SelectorIndex++;
            }
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void SelectLeft()
        {
            if (inventoryHUD.GetUnlockCount() < 2)
            {
                return;
            }
            if (SelectorIndex == 0)
                SelectorIndex = 7;
            else SelectorIndex--;
            while (!PosDictionary[SelectorIndex].unlock)
            {
                if (SelectorIndex == 0)
                    SelectorIndex = 7;
                else
                    SelectorIndex--;
            }
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void SelectUp()
        {
            int tempIndex = SelectorIndex + 4;
            if (PosDictionary[tempIndex % 8].unlock)
            {
                SelectorIndex = tempIndex % 8;
            }
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void SelectDown()
        {
            int tempIndex = SelectorIndex + 4;
            if (PosDictionary[tempIndex % 8].unlock)
            {
                SelectorIndex = tempIndex % 8;
            }
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }
       

        public int SelectCurrentItem()
        {
            return SelectorIndex;
        }
    }
}
