using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class HUDMapElement
    {
        private static HUDMapElement instance;

        private const int scale = 4;
        private const int miniMapSize = 64;
        private const int mapSize = 64;

        private Vector2 MiniMapHUDBasePos;
        private Vector2 MapHUDBasePos;

        private List<int> MiniMapList;
        private List<int> MapList;

        private Dictionary<int, Vector2> MiniMapIndicator;
        //private Dictionary<int, Vector2> MapIndicator;

        public HUDMapElement()
        {
            MiniMapHUDBasePos = new Vector2(GameState.CameraController.HUDLocation.X + 16 * scale, GameState.CameraController.HUDLocation.Y + 16 * scale);
            MapHUDBasePos = new Vector2(GameState.CameraController.ItemMenuLocation.X + 127 * scale, GameState.CameraController.ItemMenuLocation.Y + 94 * scale);
        }

        public static HUDMapElement GetInstance()
        {
            if (instance == null)
                instance = new HUDMapElement();

            return instance;
        }

        public List<int> GetMiniMapList(int level)
        {
            switch(level)
            {
                case 1:
                    MiniMapList = new List<int>()
                    {
                        -1, -1, -1, -1, -1, -1, -1, -1,
                        -1, -1,  0,  2, -1,  1,  1, -1,
                        -1,  0,  2,  2,  2,  0, -1, -1,
                        -1, -1,  1,  2,  1, -1, -1, -1
                    };
                    break;
                case 2:
                    MiniMapList = new List<int>()
                    {
                        -1, -1, -1,  0,  2,  1, -1, -1,
                        -1, -1, -1, -1,  2,  2, -1, -1,
                        -1, -1, -1, -1,  2,  2, -1, -1,
                        -1, -1,  0,  2,  2,  0, -1, -1
                    };
                    break;
            }
            return MiniMapList;
        }

        public Dictionary<int, Vector2> GetMiniMapIndicator(int level)
        {
            switch (level)
            {
                case 1:
                    MiniMapIndicator = new Dictionary<int, Vector2>()
                    {
                        { 16, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 8 * scale) },
                        { 12, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        { 17, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 8 * scale) },
                        { 13, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        { 14, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        { 15, new Vector2(MiniMapHUDBasePos.X + 50 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        {  7, new Vector2(MiniMapHUDBasePos.X + 10 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  8, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  4, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 20 * scale) },
                        {  9, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  5, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 20 * scale) },
                        { 10, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  6, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 20 * scale) },
                        { 11, new Vector2(MiniMapHUDBasePos.X + 40 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  0, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 28 * scale) },
                        {  3, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 24 * scale) },
                        {  1, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 28 * scale) },
                        {  2, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 28 * scale) },
                        { 19, new Vector2(MiniMapHUDBasePos.X, MiniMapHUDBasePos.Y) },
                        { 18, new Vector2(MiniMapHUDBasePos.X, MiniMapHUDBasePos.Y) }
                    };
                    break;
                case 2:
                    MiniMapIndicator = new Dictionary<int, Vector2>()
                    {
                        { 16, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y) },
                        { 17, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y) },
                        { 14, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 4 * scale) },
                        { 15, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 4 * scale) },
                        { 12, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 8 * scale) },
                        { 10, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        { 13, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 8 * scale) },
                        { 11, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 12 * scale) },
                        {  8, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  6, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 20 * scale) },
                        {  9, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 16 * scale) },
                        {  7, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 20 * scale) },
                        {  2, new Vector2(MiniMapHUDBasePos.X + 18 * scale, MiniMapHUDBasePos.Y + 24 * scale) },
                        {  3, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 24 * scale) },
                        {  0, new Vector2(MiniMapHUDBasePos.X + 26 * scale, MiniMapHUDBasePos.Y + 28 * scale) },
                        {  4, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 24 * scale) },
                        {  1, new Vector2(MiniMapHUDBasePos.X + 34 * scale, MiniMapHUDBasePos.Y + 28 * scale) },
                        {  5, new Vector2(MiniMapHUDBasePos.X + 42 * scale, MiniMapHUDBasePos.Y + 24 * scale) }
                    };
                    break;
            }
            return MiniMapIndicator;
        }

        public List<int> GetMapList(int level)
        {
            switch (level)
            {
                case 1:
                    MapList = new List<int>()
                    {
                        -1, -1, -1, -1, -1, -1, -1, -1,
                        -1, -1, -1, -1, -1, -1, -1, -1,
                        -1, -1, -1,  4, -1, -1, -1, -1,
                        -1, -1, -1, 12, -1,  4, -1, -1,
                        -1,  1,  5, 11,  3, 10, -1, -1,
                        -1, -1,  8,  7, -1, -1, -1, -1,
                        -1, -1, -1,  4, -1, -1, -1, -1,
                        -1, -1,  1, 15,  2, -1, -1, -1
                    };
                    break;
                case 2:
                    MapList = new List<int>()
                    {
                        -1, -1, -1,  1,  6, -1, -1, -1,
                        -1, -1, -1, -1, 13,  6, -1, -1,
                        -1, -1, -1, -1, 13, 14, -1, -1,
                        -1, -1, -1, -1, 13, 14, -1, -1,
                        -1, -1, -1, -1, 13, 14, -1, -1,
                        -1, -1, -1, -1, 13, 14, -1, -1,
                        -1, -1,  1,  7, 15, 10, -1, -1,
                        -1, -1, -1, 13, 10, -1, -1, -1
                    };
                    break;
            }
            return MapList;
        }

        public Dictionary<int, Vector2> GetMapIndicator(int level)
        {
            switch (level)
            {
                case 1:
                    MiniMapIndicator = new Dictionary<int, Vector2>()
                    {
                        { 16, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 20 * scale) },
                        { 17, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 20 * scale) },
                        { 12, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 28 * scale) },
                        { 13, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 28 * scale) },
                        { 14, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 28 * scale) },
                        { 15, new Vector2(MapHUDBasePos.X + 52 * scale, MapHUDBasePos.Y + 28 * scale) },
                        {  7, new Vector2(MapHUDBasePos.X + 12 * scale, MapHUDBasePos.Y + 36 * scale) },
                        {  8, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 36 * scale) },
                        {  9, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 36 * scale) },
                        { 10, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 36 * scale) },
                        { 11, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 36 * scale) },
                        {  4, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 44 * scale) },
                        {  5, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 44 * scale) },
                        {  6, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 44 * scale) },
                        {  3, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 52 * scale) },
                        {  0, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 60 * scale) },
                        {  1, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 60 * scale) },
                        {  2, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 60 * scale) },
                        { 19, new Vector2(MapHUDBasePos.X, MapHUDBasePos.Y) }
                    };
                    break;
                case 2:
                    MiniMapIndicator = new Dictionary<int, Vector2>()
                    {
                        { 16, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 4 * scale) },
                        { 17, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 4 * scale) },
                        { 14, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 12 * scale) },
                        { 15, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 12 * scale) },
                        { 12, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 20 * scale) },
                        { 13, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 20 * scale) },
                        { 10, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 28 * scale) },
                        { 11, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 28 * scale) },
                        {  8, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 36 * scale) },
                        {  9, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 36 * scale) },
                        {  6, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 44 * scale) },
                        {  7, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 44 * scale) },
                        {  2, new Vector2(MapHUDBasePos.X + 20 * scale, MapHUDBasePos.Y + 52 * scale) },
                        {  3, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 52 * scale) },
                        {  4, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 52 * scale) },
                        {  5, new Vector2(MapHUDBasePos.X + 44 * scale, MapHUDBasePos.Y + 52 * scale) },
                        {  0, new Vector2(MapHUDBasePos.X + 28 * scale, MapHUDBasePos.Y + 60 * scale) },
                        {  1, new Vector2(MapHUDBasePos.X + 36 * scale, MapHUDBasePos.Y + 60 * scale) }
                    };
                    break;
            }
            return MiniMapIndicator;
        }
    }
}
