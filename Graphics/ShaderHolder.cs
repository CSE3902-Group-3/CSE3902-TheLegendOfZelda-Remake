using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public static class ShaderHolder
    {
        public static readonly bool ShadersOn = false;
        //private static bool loaded = false;
        public static Effect normalShader;

        public static Effect Standard { get; private set; }

        public static Effect Flash1 { get; private set; }
        public static Effect Flash2 { get; private set; }
        public static Effect Blink { get; private set; }
        public static Effect StandardPallet { get; private set; }

        

        private static List<Vector4[]> cyclePalletteList;
        private static int currentPallette = 0;

        public static void LoadShaders(ContentManager content)
        {
            PalletHolder.LoadPallettes();
            cyclePalletteList = PalletHolder.mainPallettes;

            Standard = content.Load<Effect>("normal");
            StandardPallet = content.Load<Effect>("pallet");
            Flash1 = StandardPallet.Clone();
            Flash2 = StandardPallet.Clone();
            Blink = StandardPallet.Clone();

            StandardPallet.Parameters["Pallet"].SetValue(PalletHolder.normalPallette);
            Flash1.Parameters["Pallet"].SetValue(PalletHolder.flash1Pallette);
            Flash2.Parameters["Pallet"].SetValue(PalletHolder.flash2Pallette);
            Blink.Parameters["Pallet"].SetValue(PalletHolder.flash3Pallette);

            normalShader = ShadersOn ? StandardPallet : Standard;

            //loaded = true;
        }

        public static void CyclePalletteForward()
        {
            if(!ShadersOn) return;

            currentPallette = (currentPallette + 1) % cyclePalletteList.Count;
            StandardPallet.Parameters["Pallet"].SetValue(cyclePalletteList[currentPallette]);
        }

        public static void CyclePalletteBackward()
        {
            if(!ShadersOn) return;

            currentPallette--;
            if (currentPallette < 0) currentPallette = cyclePalletteList.Count - 1;
            StandardPallet.Parameters["Pallet"].SetValue(cyclePalletteList[currentPallette]);
        }

        public static void SetPallette(Vector4[] newPallette)
        {
            if (!ShadersOn) return;

            if (newPallette.Length != 32) return;
            StandardPallet.Parameters["Pallet"].SetValue(newPallette);
        }
    }
}
