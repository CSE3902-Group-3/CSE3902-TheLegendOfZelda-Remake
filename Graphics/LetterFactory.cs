using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class LetterFactory
    {
        private static LetterFactory instance;

        private Texture2D letterTexture;

        public AnimatedSprite letterSprite;

        private Game1 game1;
        private int drawFramesPerAnimFrame;
        private const int slowAnimateFactor = 2;
        private const int fastDrawFramesPerAnimFrame = 2;
        public int scale { get; private set; }

        private const int letterWidth = 8;
        private int XPos;
        private int YPos;

        private LetterFactory(int scale)
        {
            game1 = Game1.getInstance();
            letterTexture = game1.Content.Load<Texture2D>("Dungeon");
            drawFramesPerAnimFrame = 1;
            this.scale = scale;
        }

        public static LetterFactory GetInstance()
        {
            if (instance == null)
                instance = new LetterFactory(4);

            return instance;
        }

        public AnimatedSprite GetLetterSprite(int number)
        {
            if (number % 2 != 0)
            {
                number = number / 2;
                XPos = 1 + number * letterWidth;
                YPos = 19;
            }
            else
            {
                number = number / 2;
                XPos = 1 + number * letterWidth;
                YPos = 11;
            }

            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(XPos, YPos, letterWidth, letterWidth)
            };
            letterSprite = new AnimatedSprite(letterTexture, frames, SpriteEffects.None, 1, scale);

            return letterSprite;
        }

        public AnimatedSprite GetLetterSprite(char character)
        {
            int number = character - 'A';

            if (number % 2 != 0 && number < 22)
            {
                number = number / 2;
                XPos = 41 + number * letterWidth;
                YPos = 19;
            }
            else if (number % 2 == 0 && number < 22)
            {
                number = number / 2;
                XPos = 41 + number * letterWidth;
                YPos = 11;
            }
            else if ((number - 22) % 2 == 0)
            {
                number = (number - 22) / 2;
                XPos = 1 + number * letterWidth;
                YPos = 27;
            }
            else if ((number - 22) % 2 != 0)
            {
                number = (number - 22) / 2;
                XPos = 1 + number * letterWidth;
                YPos = 35;
            }


            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(XPos, YPos, letterWidth, letterWidth)
            };
            letterSprite = new AnimatedSprite(letterTexture, frames, SpriteEffects.None, 1, scale);

            return letterSprite;
        }

        public AnimatedSprite GetLetterSprite(char character, int color)
        {
            int number = character - 'A';
            int colorOffset;

            switch(color)
            {
                case 0:
                    colorOffset = 0;
                    break;
                case 1:
                    colorOffset = 129;
                    break;
                case 2:
                    colorOffset = 258;
                    break;
                case 3:
                    colorOffset = 387;
                    break;
                default:
                    colorOffset = 0;
                    break;
            }

            if (number % 2 != 0 && number < 22)
            {
                number = number / 2;
                XPos = 41 + colorOffset + number * letterWidth;
                YPos = 19;
            }
            else if (number % 2 == 0 && number < 22)
            {
                number = number / 2;
                XPos = 41 + colorOffset + number * letterWidth;
                YPos = 11;
            }
            else if ((number - 22) % 2 == 0)
            {
                number = (number - 22) / 2;
                XPos = 1 + colorOffset + number * letterWidth;
                YPos = 27;
            }
            else if ((number - 22) % 2 != 0)
            {
                number = (number - 22) / 2;
                XPos = 1 + colorOffset + number * letterWidth;
                YPos = 35;
            }


            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(XPos, YPos, letterWidth, letterWidth)
            };
            letterSprite = new AnimatedSprite(letterTexture, frames, SpriteEffects.None, 1, scale);

            return letterSprite;
        }

        public AnimatedSprite GetBlankSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(17, 27, letterWidth, letterWidth)
            };
            letterSprite = new AnimatedSprite(letterTexture, frames, SpriteEffects.None, 1, scale);

            return letterSprite;
        }

    }
}
