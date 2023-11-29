using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public static class PalletHolder
    {
        public static Vector4[] normalPallette { get; private set; }
        public static Vector4[] dung2Pallette { get; private set; }
        public static Vector4[] grayPallette { get; private set; }
        public static Vector4[] blackPallette { get; private set; }
        public static Vector4[] invertedPallette { get; private set; }
        public static Vector4[] rot1Pallette { get; private set; }
        public static Vector4[] rot2Pallette { get; private set; }
        public static Vector4[] scarletPallette { get; private set; }

        public static Vector4[] flash1Pallette { get; private set; }
        public static Vector4[] flash2Pallette { get; private set; }
        public static Vector4[] flash3Pallette { get; private set; }

        public static List<Vector4[]> mainPallettes;

        public static void LoadPallettes()
        {
            mainPallettes = new List<Vector4[]>();

            normalPallette = new Vector4[32]
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
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };
            mainPallettes.Add(normalPallette);

            flash1Pallette = new Vector4[32]
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
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            flash2Pallette = new Vector4[32]
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
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            flash3Pallette = new Vector4[32]
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
                new Vector4(24/255f, 60/255f, 92/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };

            dung2Pallette = new Vector4[32]
            {
                new Vector4(0, 0, 0, 1),
                new Vector4(196/255f, 212/255f, 252/255f, 1),
                new Vector4(200/255f, 76/255f, 12/255f, 1),
                new Vector4(252/255f, 152/255f, 56/255f, 1),
                new Vector4(1, 1, 1, 1),
                new Vector4(252/255f, 152/255f, 56/255f, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(1, 0, 0, 1),
                new Vector4(92/255f, 148/255f, 252/255f, 1),
                new Vector4(32/255f, 56/255f, 236/255f, 1),
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
                new Vector4(0, 0, 168/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1),
                new Vector4(0/255f, 0/255f, 0/255f, 1)
            };
            mainPallettes.Add(dung2Pallette);

            //Grayscale pallette
            grayPallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                float averageBrightness = (normalPallette[i].X + normalPallette[i].Y + normalPallette[i].Z) / 3;
                grayPallette[i] = new Vector4(averageBrightness, averageBrightness, averageBrightness, 1);
            }
            mainPallettes.Add(grayPallette);

            //BW pallette
            blackPallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                float averageBrightness = (normalPallette[i].X + normalPallette[i].Y + normalPallette[i].Z) / 3;
                averageBrightness = (averageBrightness < 100 / 255f) ? 0 : 1;
                blackPallette[i] = new Vector4(averageBrightness, averageBrightness, averageBrightness, 1);
            }
            mainPallettes.Add(blackPallette);

            //Inversion pallette
            invertedPallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                Vector4 color = normalPallette[i];
                invertedPallette[i] = new Vector4(1f - color.X, 1f - color.Y, 1f - color.Z, 1);
            }
            mainPallettes.Add(invertedPallette);

            //Rotation 1
            rot1Pallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                Vector4 color = normalPallette[i];
                rot1Pallette[i] = new Vector4(color.Y, color.Z, color.X, 1);
            }
            mainPallettes.Add(rot1Pallette);

            //Rotation 2
            rot2Pallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                Vector4 color = normalPallette[i];
                rot2Pallette[i] = new Vector4(color.Z, color.X, color.Y, 1);
            }
            mainPallettes.Add(rot2Pallette);

            //Scarlet and Gray
            scarletPallette = new Vector4[32];
            for (int i = 0; i < 32; i++)
            {
                float maxC = Math.Max(normalPallette[i].X, normalPallette[i].Y);
                maxC = Math.Max(maxC, normalPallette[i].Z);
                float minC = Math.Min(normalPallette[i].X, normalPallette[i].Y);
                minC = Math.Min(minC, normalPallette[i].Z);

                float averageBrightness = (normalPallette[i].X + normalPallette[i].Y + normalPallette[i].Z) / 3;

                if(maxC - minC > 150/255f && maxC > 200/255f)
                {
                    scarletPallette[i] = new Vector4(averageBrightness, 0, 0, 1);
                } else
                {
                    scarletPallette[i] = new Vector4(averageBrightness, averageBrightness, averageBrightness, 1);
                }
                
            }
            mainPallettes.Add(scarletPallette);
        }
    }
}
