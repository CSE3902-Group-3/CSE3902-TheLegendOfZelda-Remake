using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public class Explosion : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private Game1 game;
        public Explosion(Vector2 position)
        {
            game = Game1.getInstance();
            SpriteFactory spriteFactory = game.spriteFactory;
            game.RegisterUpdateable(this);

            sprite = spriteFactory.CreateExplosionSprite();
            sprite.UpdatePos(position);
        }

        public void Update(GameTime gameTime)
        {
            if (sprite.complete)
            {
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

