using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Map : IItem
    {
        private Game1 game1;
        protected AnimatedSprite map;
        private SpriteFactory spriteFactory;


        public Map()
        {
            game1 = Game1.instance;
            spriteFactory = game1.spriteFactory;
            map = spriteFactory.CreateMapSprite();
        }

        public void Remove()
        {
            map.UnregisterSprite();
        }

        public void Collect()
        {
            //left empty for sprint2
        }
    }
}

