using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda
{
    public static class ShaderHolder
    {
        public static readonly bool ShadersOn = true;
        private static bool loaded = false;
        public static Effect normalShader;

        public static Effect standard;
        public static Effect flash1;
        public static Effect flash2;
        public static Effect blink;

        public static Effect standardPallet;

        private static Texture2D pallet0;

        public static void LoadShaders(ContentManager content)
        {
            standard = content.Load<Effect>("normal");
            standardPallet = content.Load<Effect>("pallet");
            flash1 = standardPallet.Clone();
            flash2 = standardPallet.Clone();
            blink = standardPallet.Clone();

            Vector4[] normalPallette = new Vector4[32]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(128/255f, 208/255f, 16/255f, 1),
                new Vector4(200/255f, 76/255f, 12/255f, 1),
                new Vector4(252/255f, 152/255f, 56/255f, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(92/255f, 148/255f, 1, 1),
                new Vector4(0, 0, 168/255f, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(0, 232/255f, 216/255f, 1),
                new Vector4(0, 128/255f, 136/255f, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(72/255f, 205/255f, 222/255f, 1),
                new Vector4(146/255f, 144/255f, 255/255f, 1),
                new Vector4(153/255f, 78/255f, 0, 1),
                new Vector4(252/255f, 188/255f, 176/255f, 1),
                new Vector4(240/255f, 188/255f, 60/255f, 1),
                new Vector4(0/255f, 168/255f, 0/255f, 1),
                new Vector4(64/255f, 44/255f, 0/255f, 1),
                new Vector4(252/255f, 216/255f, 168/255f, 1),
                new Vector4(176/255f, 252/255f, 204/255f, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(0/255f, 80/255f, 0/255f, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(231/255f, 156/255f, 33/255f, 1),
                new Vector4(32/255f, 56/255f, 236/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            Vector4[] flash1Pallette = new Vector4[32]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(0, 0, 0, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(0/255f, 128/255f, 136/255f, 1),
                new Vector4(200/255f, 76/255f, 12/255f, 1),
                new Vector4(240/255f, 188/255f, 60, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(128/255f, 208/255f, 16/255f, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(1, 255/255f, 255/255f, 1),
                new Vector4(252/255f, 152/255f, 56/255f, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(72/255f, 205/255f, 222/255f, 1),
                new Vector4(146/255f, 144/255f, 255/255f, 1),
                new Vector4(153/255f, 78/255f, 0, 1),
                new Vector4(252/255f, 188/255f, 176/255f, 1),
                new Vector4(240/255f, 188/255f, 60/255f, 1),
                new Vector4(0/255f, 168/255f, 0/255f, 1),
                new Vector4(64/255f, 44/255f, 0/255f, 1),
                new Vector4(252/255f, 216/255f, 168/255f, 1),
                new Vector4(176/255f, 252/255f, 204/255f, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(128/255f, 208/255f, 16/255f, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(231/255f, 156/255f, 33/255f, 1),
                new Vector4(32/255f, 56/255f, 236/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            Vector4[] flash2Pallette = new Vector4[32]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(252/255f, 152/255f, 56/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(0/255f, 232/255f, 216/255f, 1),
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(153/255f, 78/255f, 0/255f, 1),
                new Vector4(176/255f, 252/255f, 204/255f, 1),
                new Vector4(200/255f, 76/255f, 12/255f, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(72/255f, 205/255f, 222/255f, 1),
                new Vector4(146/255f, 144/255f, 255/255f, 1),
                new Vector4(153/255f, 78/255f, 0, 1),
                new Vector4(252/255f, 188/255f, 176/255f, 1),
                new Vector4(240/255f, 188/255f, 60/255f, 1),
                new Vector4(0/255f, 168/255f, 0/255f, 1),
                new Vector4(64/255f, 44/255f, 0/255f, 1),
                new Vector4(252/255f, 216/255f, 168/255f, 1),
                new Vector4(176/255f, 252/255f, 204/255f, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(231/255f, 156/255f, 33/255f, 1),
                new Vector4(32/255f, 56/255f, 236/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            Vector4[] flash3Pallette = new Vector4[32]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(0, 0, 168/255f, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(92/255f, 148/255f, 1, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(0, 0, 168/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(188/255f, 188/255f, 188/255f, 1),
                new Vector4(116/255f, 116/255f, 116/255f, 1),
                new Vector4(72/255f, 205/255f, 222/255f, 1),
                new Vector4(146/255f, 144/255f, 255/255f, 1),
                new Vector4(153/255f, 78/255f, 0, 1),
                new Vector4(252/255f, 188/255f, 176/255f, 1),
                new Vector4(240/255f, 188/255f, 60/255f, 1),
                new Vector4(0/255f, 168/255f, 0/255f, 1),
                new Vector4(64/255f, 44/255f, 0/255f, 1),
                new Vector4(252/255f, 216/255f, 168/255f, 1),
                new Vector4(176/255f, 252/255f, 204/255f, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(0, 0, 0, 1),
                new Vector4(181/255f, 49/255f, 33/255f, 1),
                new Vector4(254/255f, 205/255f, 196/255f, 1),
                new Vector4(231/255f, 156/255f, 33/255f, 1),
                new Vector4(32/255f, 56/255f, 236/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            standardPallet.Parameters["Pallet"].SetValue(normalPallette);
            flash1.Parameters["Pallet"].SetValue(flash1Pallette);
            flash2.Parameters["Pallet"].SetValue(flash2Pallette);
            blink.Parameters["Pallet"].SetValue(flash3Pallette);

            normalShader = standardPallet;

            loaded = true;
        }
    }
}
