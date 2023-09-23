using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Block
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

        private bool _enabled;
        public bool enabled
        {
            get { return  enabled; }
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
                _enabled = value;
            }
        }

        public Block(AnimatedSprite sprite, Vector2 pos) {
            this.sprite = sprite;
            this.pos = pos;
            sprite.UpdatePos(pos);
        }
    }
}
