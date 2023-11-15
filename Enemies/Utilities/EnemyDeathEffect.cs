using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int createdInRoom;
        private Func<bool> CheckRoom;
        public EnemyDeathEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyDie, 1.0f, 0.0f, 0.0f);
            Sprite.UpdatePos(position);
            createdInRoom = LevelMaster.CurrentRoom;
            CheckRoom = () => createdInRoom == LevelMaster.CurrentRoom;
            new ConditionTimer(0.5, Dissipate, CheckRoom);
        }

        public void Dissipate()
        {
            Sprite.UnregisterSprite();
        }
    }
}

