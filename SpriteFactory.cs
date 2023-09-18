using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class SpriteFactory
    {
        private Texture2D linkTexture;
        private Texture2D enemiesTexture;
        private Texture2D dungeonTexture;
        private Texture2D bossesTexture;

        private Game1 game1;
        private int drawFramesPerAnimFrame;
        private int scale;

        public SpriteFactory(int drawFramesPerAnimFrame, int scale) {
            game1 = Game1.instance;
            this.drawFramesPerAnimFrame = drawFramesPerAnimFrame;
            this.scale = scale;
        }

        public void LoadTextures()
        {
            ContentManager content = game1.Content;
            linkTexture = content.Load<Texture2D>("Link");
            dungeonTexture = content.Load<Texture2D>("Dungeon");
            enemiesTexture = content.Load<Texture2D>("Enemies");
            bossesTexture = content.Load<Texture2D>("Bosses");
        }
    
        public AnimatedSprite CreateLinkWalkDownSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(1, 11, 16, 16),
                new Rectangle(18, 11, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWalkRightSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(35, 11, 16, 16),
                new Rectangle(52, 11, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWalkLeftSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(35, 11, 16, 16),
                new Rectangle(52, 11, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWalkUpSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(69, 11, 16, 16),
                new Rectangle(86, 11, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkThrowDownSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(107, 11, 16, 16),
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkThrowRightSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(124, 11, 16, 16),
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }
        public AnimatedSprite CreateLinkThrowLeftSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(124, 11, 16, 16),
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkThrowUpSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(141, 11, 16, 16),
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkGetItemSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(213, 11, 16, 16),
                new Rectangle(231, 11, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWoodStabDownSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(1, 47, 16, 28),
                new Rectangle(18, 47, 16, 28),
                new Rectangle(35, 47, 16, 28),
                new Rectangle(52, 47, 16, 28)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWoodStabUpSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(1, 97, 16, 28),
                new Rectangle(18, 97, 16, 28),
                new Rectangle(35, 97, 16, 28),
                new Rectangle(52, 97, 16, 28)
            };

            return new StabUpSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWoodStabRightSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(1, 77, 16, 16),
                new Rectangle(18, 77, 27, 16),
                new Rectangle(46, 77, 23, 16),
                new Rectangle(70, 77, 19, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateLinkWoodStabLeftSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(1, 77, 16, 16),
                new Rectangle(18, 77, 27, 16),
                new Rectangle(46, 77, 23, 16),
                new Rectangle(70, 77, 19, 16)
            };

            return new StabLeftSprite(linkTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateArrowUpSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(3, 185, 5, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateArrowDownSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(3, 185, 5, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.FlipVertically, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateArrowRightSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(10, 190, 16, 5)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateArrowLeftSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(10, 190, 16, 5)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateBurstSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(53, 189, 8, 8)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateBoomerangSprite()
        {
            Rectangle[] frames = new Rectangle[3]
            {
                new Rectangle(64, 189, 8, 8),
                new Rectangle(73, 189, 8, 8),
                new Rectangle(82, 189, 8, 8)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateBombSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(129, 185, 8, 14)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateExplosionSprite()
        {
            Rectangle[] frames = new Rectangle[3]
            {
                new Rectangle(138, 185, 16, 16),
                new Rectangle(155, 185, 16, 16),
                new Rectangle(172, 185, 16, 16)
            };

            return new AnimatedSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateFireSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(191, 185, 16, 16)
            };

            return new MirrorSprite(linkTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateGelSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(1, 11, 8, 16),
                new Rectangle(10, 11, 8, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateZolSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(77, 11, 16, 16),
                new Rectangle(94, 11, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateKeeseSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(183, 11, 16, 16),
                new Rectangle(200, 11, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateGoriyaDownSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(222, 11, 16, 16)
            };

            return new MirrorSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateGoriyaUpSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(239, 11, 16, 16)
            };

            return new MirrorSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateGoriyaRightSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(256, 11, 16, 16),
                new Rectangle(273, 11, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateGoriyaLeftSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(256, 11, 16, 16),
                new Rectangle(273, 11, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateWallmasterSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(393, 11, 16, 16),
                new Rectangle(410, 11, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateStalfosSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(1, 59, 16, 16)
            };

            return new MirrorSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateRopeRightSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(126, 59, 16, 16),
                new Rectangle(143, 59, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateRopeLeftSprite()
        {
            Rectangle[] frames = new Rectangle[2]
            {
                new Rectangle(126, 59, 16, 16),
                new Rectangle(143, 59, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.FlipHorizontally, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateBladeTrapSprite()
        {
            Rectangle[] frames = new Rectangle[1]
            {
                new Rectangle(164, 59, 16, 16)
            };

            return new AnimatedSprite(enemiesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

        public AnimatedSprite CreateAquamentusSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(1, 11, 24, 32),
                new Rectangle(26, 11, 24, 32),
                new Rectangle(51, 11, 24, 32),
                new Rectangle(76, 11, 24, 32)
            };

            return new AnimatedSprite(bossesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }
        public AnimatedSprite CreateAquamentusBallSprite()
        {
            Rectangle[] frames = new Rectangle[4]
            {
                new Rectangle(101, 11, 8, 16),
                new Rectangle(110, 11, 8, 16),
                new Rectangle(119, 11, 8, 16),
                new Rectangle(128, 11, 8, 16)
            };

            return new AnimatedSprite(bossesTexture, frames, SpriteEffects.None, drawFramesPerAnimFrame, scale);
        }

    }
}
