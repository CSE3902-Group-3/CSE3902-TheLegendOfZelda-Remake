using LegendOfZelda;
using Microsoft.Xna.Framework;
using System.Reflection.PortableExecutable;

namespace LegendOfZelda
{
    public class ArrowProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private const float speed = 2;
        private Vector2 pos;
        private Vector2 dir;
        private Vector2 viewportSize;
        public ArrowProjectile(Vector2 position, Direction direction)
        {
            game = Game1.getInstance();
            SpriteFactory spriteFactory = SpriteFactory.getInstance();
            pos = position;
            viewportSize = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);

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

            if(pos.X > viewportSize.X || pos.X < 0 || pos.Y > viewportSize.Y || pos.Y < 0){
                Destroy();
            }
        }

        public void Destroy()
        {
            sprite.UnregisterSprite();
            game.RemoveUpdateable(this);
        }
    }
}
