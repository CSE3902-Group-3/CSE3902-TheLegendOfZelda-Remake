using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public static class ShaderHolder
    {
        public static readonly bool ShadersOn = true;
        private static bool loaded = false;
        public static Effect normalShader;
        public static Effect flash1;
        public static Effect flash2;
        public static Effect blink;

        public static void LoadShaders(ContentManager content)
        {
            normalShader = content.Load<Effect>("normal");
            flash1 = content.Load<Effect>("flash1");
            flash2 = content.Load<Effect>("flash2");
            blink = content.Load<Effect>("blink");
            loaded = true;
        }
    }
}
