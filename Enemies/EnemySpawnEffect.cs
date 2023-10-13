using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemySpawnEffect: IUpdateable
    {
        private readonly AnimatedSprite Sprite;
        public EnemySpawnEffect(Vector2 position)
        {
            Game1.getInstance().RegisterUpdateable(this);
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
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

