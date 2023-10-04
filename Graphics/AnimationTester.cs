using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class AnimationTester : IUpdateable
    {
        SpriteFactory spriteFactory;
        BlockCycler blockCycler;
        EnemyCycler enemyCycler;
        ItemScroll itemScroll;
        List<AnimatedSprite> sprites;
        double lastSwitch = 0;
        double lastPause = 0;
        int counter = 0;

        Link testLink;

        public AnimationTester() {
            Game1.getInstance().RegisterUpdateable(this);
            spriteFactory = SpriteFactory.getInstance();
            // blockCycler = Game1.getInstance().blockCycler;
            // enemyCycler = Game1.getInstance().enemyCycler;
            // itemScroll = new ItemScroll(new Vector2(200,200));

            sprites = new List<AnimatedSprite>();
            //testLink = new Link(Game1.getInstance());
            
            
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
            sprites.Add(spriteFactory.CreateHeartSprite());
            sprites.Add(spriteFactory.CreateHalfHeartSprite());
            sprites.Add(spriteFactory.CreateEmptyHeartSprite());
            sprites.Add(spriteFactory.CreateBlueHeartSprite());
            sprites.Add(spriteFactory.CreateHeartContainerSprite());
            sprites.Add(spriteFactory.CreateFairySprite());
            sprites.Add(spriteFactory.CreateClockSprite());
            sprites.Add(spriteFactory.CreateRupeeSprite());
            sprites.Add(spriteFactory.CreateBluePotionSprite());
            sprites.Add(spriteFactory.CreateMapSprite());
            sprites.Add(spriteFactory.CreateBoomerangItemSprite());
            sprites.Add(spriteFactory.CreateBowSprite());
            sprites.Add(spriteFactory.CreateBlueCandleSprite());
            sprites.Add(spriteFactory.CreateKeySprite());
            sprites.Add(spriteFactory.CreateCompassSprite());
            sprites.Add(spriteFactory.CreateTriforcePieceSprite());
            sprites.Add(spriteFactory.CreateDodongoDownHitSprite());
            sprites.Add(spriteFactory.CreateDodongoDownSprite());
            sprites.Add(spriteFactory.CreateDodongoUpHitSprite());
            sprites.Add(spriteFactory.CreateDodongoUpSprite());
            sprites.Add(spriteFactory.CreateDodongoLeftHitSprite());
            sprites.Add(spriteFactory.CreateDodongoLeftSprite());
            sprites.Add(spriteFactory.CreateDodongoRightHitSprite());
            sprites.Add(spriteFactory.CreateDodongoRightSprite());
            



            foreach (AnimatedSprite sprite in sprites)
            {
                sprite.UnregisterSprite();
            }
        }

        public void Update(GameTime gameTime)
        {
            
            if(gameTime.TotalGameTime.TotalMilliseconds > lastSwitch + 3000)
            {
                lastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                sprites[counter].UnregisterSprite();
                counter++;
                if (counter >= sprites.Count) counter = 0;
                sprites[counter].RegisterSprite();
                sprites[counter].UpdatePos(new Vector2(400, 200));
                // blockCycler.cycleForward();
                // enemyCycler.CycleForward();
                //itemScroll.nextItem();
            }
            

            
            if(gameTime.TotalGameTime.TotalMilliseconds > lastPause + 1000)
            {
                lastPause = gameTime.TotalGameTime.TotalMilliseconds;
                //sprites[counter].paused = !sprites[counter].paused;
                //sprites[counter].flashing = !sprites[counter].flashing;
                sprites[counter].blinking = true;

                //new FireProjectile(new Vector2(200, 200), Direction.left);
                //new ArrowProjectile(new Vector2(200, 200), Direction.up);
                //new BombProjectile(new Vector2(300, 200));
                //new BoomerangProjectile(new Vector2(300, 200), new Vector2(1, 1), testLink);

                //blockCycler.cycleBackward();
                //itemScroll.previousItem();
            }
            
            //sprites[counter].UpdatePos(new Vector2(sprites[counter].pos.X - 1, 200));
            
        }

    }
}
