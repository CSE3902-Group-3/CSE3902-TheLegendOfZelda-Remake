using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        public EnemyDeathEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyDie, 1.0f, 0.0f, 0.0f);
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

