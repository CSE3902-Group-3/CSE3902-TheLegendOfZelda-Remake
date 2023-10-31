using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AquamentusBallExplosion : IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        public AquamentusBallExplosion(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().BombBlow, 1.0f, 0.0f, 0.0f);
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

