using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class HeartContainer : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite heartContainer;
        private SpriteFactory spriteFactory;


        public HeartContainer(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            heartContainer = spriteFactory.CreateHeartContainerSprite();
            heartContainer.UpdatePos(pos);
        }

        public void Remove()
        {
            heartContainer.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

