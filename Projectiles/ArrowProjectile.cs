using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class ArrowProjectile : IPlayerProjectile
    {
        private ISprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private const float speed = 2;
        private Vector2 pos;
        private Vector2 dir;
        public ArrowProjectile(Vector2 position, Direction direction)
        {
            game = Game1.instance;
            SpriteFactory spriteFactory = game.spriteFactory;
            pos = position;

            switch (direction)
            {
                case Direction.up:
                    sprite = spriteFactory.CreateArrowUpSprite();
                    dir = new Vector2(0, -1);
                    break;
                case Direction.down:
                    sprite = spriteFactory.CreateArrowDownSprite();
                    dir = new Vector2(0, 1);
                    break;
                case Direction.right:
                    sprite = spriteFactory.CreateArrowRightSprite();
                    dir = new Vector2(1, 0);
                    break;
                case Direction.left:
                    sprite = spriteFactory.CreateArrowLeftSprite();
                    dir = new Vector2(-1, 0);
                    break;
            }

            sprite.UpdatePos(position);

            game.RegisterUpdateable(this);
        }

        public void Update(GameTime gameTime)
        {
            pos += dir * speed;
            sprite.UpdatePos(pos);
        }

        public void Destroy()
        {
            //Not needed for sprint 2
        }
    }
}
