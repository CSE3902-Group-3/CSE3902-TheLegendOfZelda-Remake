using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class BombProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private Game1 game;
        private SpriteFactory spriteFactory;
        private const float delay = 1000;
        private const int explosionPixelOffset = 4;
        private double startTime = 0;
        private Vector2 pos;
        public BombProjectile(Vector2 position)
        {
            game = Game1.instance;
            spriteFactory = game.spriteFactory;
            pos = position;
            game.RegisterUpdateable(this);

            sprite = spriteFactory.CreateBombSprite();
            sprite.UpdatePos(pos);
        }

        public void Update(GameTime gameTime)
        {
            if(startTime == 0)
            {
                startTime = gameTime.TotalGameTime.TotalMilliseconds;
            } else if (gameTime.TotalGameTime.TotalMilliseconds > startTime + delay)
            {
                new Explosion(new Vector2(pos.X - explosionPixelOffset * sprite.scale, pos.Y));
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
