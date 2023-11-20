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
            flash1 = content.Load<Effect>("flash1");
            flash2 = content.Load<Effect>("flash2");
            blink = content.Load<Effect>("blink");
            standardPallet = content.Load<Effect>("pallet");

            Vector4[] pallet = new Vector4[16]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(128/252f, 208/252f, 16/252f, 1),
                new Vector4(200/252f, 76/252f, 12/252f, 1),
                new Vector4(252/252f, 152/252f, 56/252f, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(92/252f, 148/252f, 1, 1),
                new Vector4(0, 0, 168/252f, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(24/252f, 60/252f, 92/252f, 1),
                new Vector4(0, 232/252f, 216/252f, 1),
                new Vector4(0, 128/252f, 136/252f, 1),
                new Vector4(188/252f, 188/252f, 188/252f, 1),
                new Vector4(116/252f, 116/252f, 116/252f, 1),
                new Vector4(0, 80/252f, 0, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(1, 0, 0, 1)
            };

            standardPallet.Parameters["Pallet"].SetValue(pallet);

            normalShader = standardPallet;

            loaded = true;
        }
    }
}
