using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemySpawnEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int createdInRoom;
        public EnemySpawnEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
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

