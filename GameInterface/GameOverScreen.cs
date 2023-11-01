using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class GameOverScreen
    {
        private List<AnimatedSprite> gameOverScreenText;
        private int offset = LetterFactory.letterWidth * SpriteFactory.getInstance().scale + 5;

        public GameOverScreen(int viewportWidth, int viewportHeight)
        {
            gameOverScreenText = new List<AnimatedSprite>();

            string text = "GAME OVER";

            // Calculate the X position to center the text horizontally
            int totalWidth = text.Length * (LetterFactory.letterWidth + offset) - offset;
            int centerX = (viewportWidth - totalWidth) / 2;

            foreach (char letterChar in text)
            {
                AnimatedSprite letter = LetterFactory.getInstance().GetLetterSprite(letterChar);
                letter.UpdatePos(new Vector2(centerX, (viewportHeight - LetterFactory.letterWidth) / 2)); // Center vertically - width/height are same
                gameOverScreenText.Add(letter);

                centerX += LetterFactory.letterWidth + offset;
            }

            foreach (AnimatedSprite letter in gameOverScreenText)
            {
                LevelMaster.RegisterDrawable(letter);
            }
        }
    }

}