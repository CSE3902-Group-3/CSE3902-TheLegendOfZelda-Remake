using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        public EnemyDeathEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

