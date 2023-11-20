using Microsoft.Xna.Framework;
using System.Collections.Generic;
namespace LegendOfZelda
{
    public class Block : ICollidable
    {
        public AnimatedSprite sprite { get; private set; }
        private Vector2 _pos;
        public Vector2 pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                sprite.UpdatePos(value);
            }
        }
        public bool Enabled
        {
            get { return Enabled; }
            set
            {
                if (value)
                {
                    sprite.RegisterSprite();
                }
                else
                {
                    sprite.UnregisterSprite();
                }
            }
        }
        public Block(AnimatedSprite sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            sprite.UpdatePos(pos);
        }
        public void OnCollision(List<CollisionInfo> collisions){}
    }
}
