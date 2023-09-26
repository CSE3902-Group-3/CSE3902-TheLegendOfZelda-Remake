using LegendOfZelda;
using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LegendOfZelda
{
    public class Map : IItem
    {
        protected AnimatedSprite map;
        private SpriteFactory spriteFactory;
        private Vector2 position;

        public Map(Vector2 pos)
        {
            spriteFactory = Game1.instance.spriteFactory;
            map = spriteFactory.CreateMapSprite();
            position = pos;
        }

        public void Show()
        {
            map.RegisterSprite();
            map.UpdatePos(position);
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

