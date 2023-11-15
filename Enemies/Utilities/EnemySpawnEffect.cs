using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemySpawnEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int createdInRoom;
        private Func<bool> CheckRoom;
        public EnemySpawnEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
            Sprite.UpdatePos(position);
            createdInRoom = LevelMaster.CurrentRoom;
            CheckRoom = () => createdInRoom == LevelMaster.CurrentRoom;
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

