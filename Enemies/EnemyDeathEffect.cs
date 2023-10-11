﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect : IUpdateable
    {
        private readonly AnimatedSprite Sprite;
        public EnemyDeathEffect(Vector2 position)
        {
            Game1.getInstance().RegisterUpdateable(this);
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            Sprite.UpdatePos(position);
        }

        public void Update(GameTime gameTime)
        {
            if (Sprite.complete)
            {
                Dissipate();
            }
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
            Game1.getInstance().RemoveUpdateable(this);
        }
    }
}
