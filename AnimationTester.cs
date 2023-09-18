using Microsoft.Xna.Framework;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AnimationTester : Interfaces.iUpdateable
    {
        SpriteFactory spriteFactory;
        List<AnimatedSprite> sprites;
        double lastSwitch = 0;
        int counter = 0;

        public AnimationTester() {
            Game1.instance.RegisterUpdateable(this);
            spriteFactory = Game1.instance.spriteFactory;

            sprites = new List<AnimatedSprite>();
            sprites.Add(spriteFactory.CreateLinkWalkDownSprite());
            sprites.Add(spriteFactory.CreateLinkWalkRightSprite());
            sprites.Add(spriteFactory.CreateLinkWalkLeftSprite());
            sprites.Add(spriteFactory.CreateLinkWalkUpSprite());
            sprites.Add(spriteFactory.CreateLinkThrowUpSprite());
            sprites.Add(spriteFactory.CreateLinkThrowDownSprite());
            sprites.Add(spriteFactory.CreateLinkThrowRightSprite());
            sprites.Add(spriteFactory.CreateLinkThrowLeftSprite());
            sprites.Add(spriteFactory.CreateLinkGetItemSprite());
            sprites.Add(spriteFactory.CreateLinkWoodStabDownSprite());
            sprites.Add(spriteFactory.CreateLinkWoodStabUpSprite());
            sprites.Add(spriteFactory.CreateLinkWoodStabLeftSprite());
            sprites.Add(spriteFactory.CreateLinkWoodStabRightSprite());
            sprites.Add(spriteFactory.CreateArrowDownSprite());
            sprites.Add(spriteFactory.CreateArrowUpSprite());
            sprites.Add(spriteFactory.CreateArrowLeftSprite());
            sprites.Add(spriteFactory.CreateArrowRightSprite());
            sprites.Add(spriteFactory.CreateBurstSprite());
            sprites.Add(spriteFactory.CreateBoomerangSprite());
            sprites.Add(spriteFactory.CreateBombSprite());
            sprites.Add(spriteFactory.CreateExplosionSprite());
            sprites.Add(spriteFactory.CreateFireSprite());
            sprites.Add(spriteFactory.CreateGelSprite());
            sprites.Add(spriteFactory.CreateZolSprite());
            sprites.Add(spriteFactory.CreateKeeseSprite());
            sprites.Add(spriteFactory.CreateGoriyaDownSprite());
            sprites.Add(spriteFactory.CreateGoriyaRightSprite());
            sprites.Add(spriteFactory.CreateGoriyaUpSprite());
            sprites.Add(spriteFactory.CreateGoriyaLeftSprite());
            sprites.Add(spriteFactory.CreateWallmasterSprite());
            sprites.Add(spriteFactory.CreateStalfosSprite());
            sprites.Add(spriteFactory.CreateRopeRightSprite());
            sprites.Add(spriteFactory.CreateRopeLeftSprite());
            sprites.Add(spriteFactory.CreateBladeTrapSprite());
            sprites.Add(spriteFactory.CreateAquamentusSprite());
            sprites.Add(spriteFactory.CreateAquamentusBallSprite());

            foreach (AnimatedSprite sprite in sprites)
            {
                sprite.UnregisterSprite();
            }
        }

        public void Update(GameTime gameTime)
        {
            if(gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 2000)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                sprites[counter].UnregisterSprite();
                counter++;
                if (counter >= sprites.Count) counter = 0;
                sprites[counter].RegisterSprite();
                sprites[counter].UpdatePos(new Vector2(400, 200));
            }
        }

    }
}
