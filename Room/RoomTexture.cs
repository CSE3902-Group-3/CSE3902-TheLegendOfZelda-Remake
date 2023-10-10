using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class RoomTexture
    {
        private static RoomTexture instance = new RoomTexture(8, 6);

        public const int FLOOR_WIDTH = 192;
        public const int FLOOR_HEIGHT = 112;

        private Texture2D dungeonTexture;

        private Game1 game;
        private int drawFramesPerAnimFrame;
        private const int slowAnimateFactor = 2;
        private int scale;

        public RoomTexture(int drawFramesPerAnimFrame, int scale)
        {
            game = Game1.getInstance();
            this.drawFramesPerAnimFrame = drawFramesPerAnimFrame;
            this.scale = scale;
        }

        public static RoomTexture getInstance()
        {
            if (instance == null)
            {
                instance = new RoomTexture(8, 6);
            }

            return instance;
        }

        public void LoadTextures()
        {
            ContentManager content = game.Content;
            dungeonTexture = content.Load<Texture2D>("Dungeon");
        }

        public AnimatedSprite CreateDungeonWall()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(521, 11, 256, 176)
            };

            AnimatedSprite newSprite = new AnimatedSprite(dungeonTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
            return newSprite;
        }

        public AnimatedSprite CreateDungeonFloor01()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(1, 192, FLOOR_WIDTH, FLOOR_HEIGHT)
            };

            AnimatedSprite newSprite = new AnimatedSprite(dungeonTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
            return newSprite;
        }

        public AnimatedSprite CreateDungeonFloor02()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(1, 307, FLOOR_WIDTH, FLOOR_HEIGHT)
            };

            AnimatedSprite newSprite = new AnimatedSprite(dungeonTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
            return newSprite;
        }
    }
}
