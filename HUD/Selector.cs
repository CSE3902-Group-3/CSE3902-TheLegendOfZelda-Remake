﻿using Microsoft.Xna.Framework;
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

        public Selector()
        {
            inventoryHUD = InventoryHUD.GetInstance();

            spriteFactory = SpriteFactory.getInstance();
            Vector2 InventoryHUDBasePos = GameState.CameraController.ItemMenuLocation;
            BasePos = new Vector2(InventoryHUDBasePos.X + 128 * scale, InventoryHUDBasePos.Y + 48 * scale);

            SelectorSprite = spriteFactory.CreateSelectorSprite();
            CreatePosDict();
        }

        public static Selector GetInstance()
        {
            if (instance == null)
                instance = new Selector();

            return instance;
        }

        /*
        public void LoadContent()
        {
            SelectorSprite = spriteFactory.CreateSelectorSprite();

            BasePos = inventoryHUD.GetSelectorPos();
            CreatePosDict();
        }
        */

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
            if (tempIndex < 4)
                if (PosDictionary[tempIndex += 4].unlock)
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
                if (PosDictionary[tempIndex += 4].unlock)
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