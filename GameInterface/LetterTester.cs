using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LetterTester
    {
        private LetterFactory letterFactory;
        private AnimatedSprite letterSprite;



        public LetterTester()
        {
            letterFactory = LetterFactory.getInstance();
        }

        public void Show()
        {
            for (int i = 0; i < 10; i++)
            {
                letterSprite = letterFactory.GetLetterSprite(i);
                letterSprite.RegisterSprite();
                letterSprite.UpdatePos(new Vector2(100 + i * 30, 70));
            }
            for (int i = 0; i < 26; i++)
            {
                letterSprite = letterFactory.GetLetterSprite((char)('A' + i));
                letterSprite.RegisterSprite();
                letterSprite.UpdatePos(new Vector2(100 + i * 30, 100));
            }
        }

        public void Remove()
        {
            letterSprite.UnregisterSprite();
        }

    }
}
