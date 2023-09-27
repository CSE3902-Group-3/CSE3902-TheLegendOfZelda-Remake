using LegendOfZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Triforce : IItem
    {
        // Modified last minute by Michael to meet functionality deadline. Needs refactoring by original author
        protected AnimatedSprite triforce;
        private SpriteFactory spriteFactory;


        public Triforce(Game1 game1, Vector2 pos)
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            triforce = spriteFactory.CreateTriforcePieceSprite();
            triforce.UpdatePos(pos);
        }

        public void Remove()
        {
            triforce.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

