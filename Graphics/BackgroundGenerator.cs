using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda.Graphics
{
    public static class BackgroundGenerator
    {
        public static ISprite ItemMenuBackground { get; private set; }
        public static ISprite StartMenuBackground { get; private set; }
        public static ISprite EndMenuBackground { get; private set; }

        public static void GenerateMenuBackgrounds()
        {
            CameraController cameraController = CameraController.GetInstance();

            Vector2 pos = cameraController.ItemMenuLocation;
            new Background((int)pos.X, (int)pos.Y);
            pos = cameraController.StartLocation;
            new Background((int)pos.X, (int)pos.Y);
            pos = cameraController.EndLocation;
            new Background((int)pos.X, (int)pos.Y);
        }
    }
}
