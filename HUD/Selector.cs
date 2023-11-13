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

        private int SelectorIndex;

        private SpriteFactory spriteFactory;

        private AnimatedSprite SelectorSprite;

        private Vector2 BasePos;

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
            SelectorIndex = 0;
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
            SelectorSprite.UpdatePos(PosDictionary[SelectorIndex].pos);
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
                    temp.pos = new Vector2(BasePos.X + (i - 4) * 24 * scale, BasePos.Y + 24 * scale);
                temp.unlock = unLockList[i];
                PosDictionary.Add(i, temp);
            }
        }

        public void SelectRight()
        {
            if (SelectorIndex == 7)
                SelectorIndex = 0;
            while (!PosDictionary[SelectorIndex].unlock)
            {
                if (SelectorIndex == 7)
                    SelectorIndex = 0;
                else
                    SelectorIndex++;
            }
        }

        public void SelectLeft()
        {
            if (SelectorIndex == 0)
                SelectorIndex = 7;
            while (!PosDictionary[SelectorIndex].unlock)
            {
                if (SelectorIndex == 0)
                    SelectorIndex = 7;
                else
                    SelectorIndex--;
            }
        }

        public void SelectUp()
        {
            if (SelectorIndex < 4)
                if (PosDictionary[SelectorIndex += 4].unlock)
                    SelectorIndex += 4;
            else
                if (PosDictionary[SelectorIndex -= 4].unlock)
                    SelectorIndex -= 4;
        }

        public void SelectDown()
        {
            if (SelectorIndex < 4)
                if (PosDictionary[SelectorIndex += 4].unlock)
                    SelectorIndex += 4;
            else
                if (PosDictionary[SelectorIndex -= 4].unlock)
                    SelectorIndex -= 4;
        }

        public int SelectCurrentItem()
        {
            return SelectorIndex;
        }
    }
}
