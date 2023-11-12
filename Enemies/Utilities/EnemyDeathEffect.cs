using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int createdInRoom;
        public EnemyDeathEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyDie, 1.0f, 0.0f, 0.0f);
            Sprite.UpdatePos(position);
            new Timer(0.5, Dissipate);
            createdInRoom = LevelMaster.CurrentRoom;
        }

        public void Dissipate()
        {
            int thisRoom = LevelMaster.CurrentRoom;
            LevelMaster.CurrentRoom = createdInRoom;
            Sprite.UnregisterSprite();
            LevelMaster.CurrentRoom = thisRoom;
        }
    }
}

