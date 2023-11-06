using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemySpawnEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        public EnemySpawnEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

