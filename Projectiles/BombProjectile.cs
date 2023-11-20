using LegendOfZelda;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class BombProjectile : IPlayerProjectile
    {
        private AnimatedSprite sprite;
        private SpriteFactory spriteFactory;
        private const double delay = 1;
        private const int explosionPixelOffset = 4;
        private Vector2 pos;
        public BombProjectile(Vector2 position)
        {
            spriteFactory = SpriteFactory.getInstance();
            pos = position;

            sprite = spriteFactory.CreateBombSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().BombDrop, 1.0f, 0.0f, 0.0f);
            sprite.UpdatePos(pos);

            new Timer(delay, SpawnExplosion);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void SpawnExplosion()
        {
            new Explosion(new Vector2(pos.X - explosionPixelOffset * sprite.scale, pos.Y));
            SoundFactory.PlaySound(SoundFactory.getInstance().BombBlow, 1.0f, 0.0f, 0.0f);
            Destroy();
        }
        public void Destroy()
        {
            sprite.UnregisterSprite();
            LevelManager.RemoveUpdateable(this);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            
        }
    }
}
