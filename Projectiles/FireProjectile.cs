using LegendOfZelda.Interfaces;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class FireProjectile : IPlayerProjectile
    {
        private ISprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private const float speed = 2;
        private Vector2 pos;
        private Vector2 dir;
        public FireProjectile(Vector2 position, Direction direction)
        {
            game = Game1.instance;
            SpriteFactory spriteFactory = game.spriteFactory;
            pos = position;

            switch (direction)
            {
                case Direction.up:
                    dir = new Vector2(0, -1);
                    break;
                case Direction.down:
                    dir = new Vector2(0, 1);
                    break;
                case Direction.right:
                    dir = new Vector2(1, 0);
                    break;
                case Direction.left:
                    dir = new Vector2(-1, 0);
                    break;
            }

            sprite = spriteFactory.CreateFireSprite();
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

