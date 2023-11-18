using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace LegendOfZelda
{
    public class WinningMenu
    {
        private List<AnimatedSprite> PlayFirstDungeon;
        private List<AnimatedSprite> PlaySecondDungeon;

        private LetterFactory letterFactory;
        private int cameraXPos;
        private int cameraYPos;
        private int letterWidth;
        private int ScreenHeight;
        private int ScreenWidth;

        public WinningMenu()
        {
            letterFactory = LetterFactory.GetInstance();
            letterWidth = 30;
            cameraXPos = (int)GameState.CameraController.EndLocation.X;
            cameraYPos = (int)GameState.CameraController.EndLocation.Y;
            ScreenHeight = 896;
            ScreenWidth = 1024;

            PlayFirstDungeon = new List<AnimatedSprite>()
            {
                letterFactory.GetLetterSprite('P'),
                letterFactory.GetLetterSprite('L'),
                letterFactory.GetLetterSprite('A'),
                letterFactory.GetLetterSprite('Y'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('F'),
                letterFactory.GetLetterSprite('I'),
                letterFactory.GetLetterSprite('R'),
                letterFactory.GetLetterSprite('S'),
                letterFactory.GetLetterSprite('T'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('D'),
                letterFactory.GetLetterSprite('U'),
                letterFactory.GetLetterSprite('N'),
                letterFactory.GetLetterSprite('G'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('N')
            };

            PlaySecondDungeon = new List<AnimatedSprite>()
            {
                letterFactory.GetLetterSprite('P'),
                letterFactory.GetLetterSprite('L'),
                letterFactory.GetLetterSprite('A'),
                letterFactory.GetLetterSprite('Y'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('S'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetLetterSprite('C'),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('N'),
                letterFactory.GetLetterSprite('D'),
                letterFactory.GetBlankSprite(),
                letterFactory.GetLetterSprite('D'),
                letterFactory.GetLetterSprite('U'),
                letterFactory.GetLetterSprite('N'),
                letterFactory.GetLetterSprite('G'),
                letterFactory.GetLetterSprite('E'),
                letterFactory.GetLetterSprite('O'),
                letterFactory.GetLetterSprite('N')
            };

        }

        private void DrawFirstDungeonWord()
        {
            int startXPos = cameraXPos + ScreenWidth / 4;
            int startYPos = cameraYPos + ScreenHeight / 3;
            for (int i = 0; i < PlayFirstDungeon.Count; i++)
            {
                PlayFirstDungeon[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
            }
        }

        private void DrawSecondDungeonWord()
        {
            int startXPos = cameraXPos + ScreenWidth / 4;
            int startYPos = cameraYPos + ScreenHeight * 2 / 3;
            for (int i = 0; i < PlaySecondDungeon.Count; i++)
            {
                PlaySecondDungeon[i].UpdatePos(new Vector2((startXPos + letterWidth * i), startYPos));
            }
        }

        public void Draw()
        {
            DrawFirstDungeonWord();
            DrawSecondDungeonWord();
        }
    }
}

