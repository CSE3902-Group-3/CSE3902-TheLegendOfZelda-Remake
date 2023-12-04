using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class AquamentusBallExplosion : IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int CreatedInRoom;
        public AquamentusBallExplosion(Vector2 position)
        {
            CreatedInRoom = LevelManager.CurrentRoom;
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().BombBlow);
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            LevelManager.RemoveDrawable(Sprite, CreatedInRoom);
        }
    }
}

