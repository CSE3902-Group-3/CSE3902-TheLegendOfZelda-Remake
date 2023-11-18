using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemySpawnEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int CreatedInRoom;
        public EnemySpawnEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateExplosionSprite();
            Sprite.UpdatePos(position);
            CreatedInRoom = LevelManager.CurrentRoom;
            new Timer(0.5, Dissipate);
        }

        public void Dissipate()
        {
            LevelManager.RemoveDrawable(Sprite, CreatedInRoom);
        }
    }
}

