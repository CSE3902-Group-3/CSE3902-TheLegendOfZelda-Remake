using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Potion : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite potion;
        private SpriteFactory spriteFactory;


        public Potion(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            potion = spriteFactory.CreateBluePotionSprite();
            potion.UpdatePos(pos);
        }

        public void Remove()
        {
            potion.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

