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
        private const int selectorInitialIndex = 0;

        InventoryHUD inventoryHUD;

        private int SelectorIndex = 0;

        private SpriteFactory spriteFactory;

        private AnimatedSprite SelectorSprite;

        private Vector2 BasePos;
        private Vector2 SelectorCurrPos;

        private struct SelectorPos
        {
            public Vector2 pos;
            public bool unlock;
        }

        private Dictionary<int, SelectorPos> PosDictionary;

        public Selector(InventoryHUD inventoryHUD)
        {
            this.inventoryHUD = inventoryHUD;

            spriteFactory = SpriteFactory.getInstance();
            this.inventoryHUD = inventoryHUD;
        }

        public static Selector GetInstance(InventoryHUD inventoryHUD)
        {
            if (instance == null)
                instance = new Selector(inventoryHUD);

            return instance;
        }

        public void LoadContent()
        {
            SelectorSprite = spriteFactory.CreateSelectorSprite();

            BasePos = inventoryHUD.GetSelectorPos();
            CreatePosDict();
        }

        public void Update()
        {
            SelectorSprite.UpdatePos(PosDictionary[SelectorIndex].pos);
        }

        public void Show()
        {
            SelectorSprite.RegisterSprite();
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void CreatePosDict()
        {
            PosDictionary = new Dictionary<int, SelectorPos>();
            List<bool> unLockList = inventoryHUD.GetUnlockList();
            for (int i = 0; i < 9; i++)
            {
                SelectorPos temp = new SelectorPos();
                if (i < 3)
                    temp.pos = new Vector2(BasePos.X + i * 24 * scale, BasePos.Y);
                else if (i < 5)
                    temp.pos = new Vector2(BasePos.X + (i - 1) * 24 * scale, BasePos.Y);
                else
                    temp.pos = new Vector2(BasePos.X + (i - 5) * 24 * scale, BasePos.Y + 16 * scale);
                temp.unlock = unLockList[i];
                PosDictionary.Add(i, temp);
            }
        }

        public void SelectRight()
        {
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
            int tempIndex = SelectorIndex;
            if (tempIndex < 5)
                if (PosDictionary[tempIndex += 5].unlock)
                    SelectorIndex = tempIndex;
            else
                if (PosDictionary[tempIndex -= 4].unlock)
                    SelectorIndex = tempIndex;
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }

        public void SelectDown()
        {
            int tempIndex = SelectorIndex;
            if (tempIndex < 4)
                if (PosDictionary[tempIndex += 5].unlock)
                    SelectorIndex = tempIndex;
            else
                if (PosDictionary[tempIndex -= 4].unlock)
                    SelectorIndex = tempIndex;
            SelectorCurrPos = PosDictionary[SelectorIndex].pos;
            SelectorSprite.UpdatePos(SelectorCurrPos);
        }
       

        public int SelectCurrentItem()
        {
            return SelectorIndex;
        }
    }
}
