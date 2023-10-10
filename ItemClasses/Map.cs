using LegendOfZelda;
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
            spriteFactory = SpriteFactory.getInstance();
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

        public IItem Collect()
        {
            map.UnregisterSprite();
            return this;
        }
    }
}

