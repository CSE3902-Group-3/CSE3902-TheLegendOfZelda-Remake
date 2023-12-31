﻿using System;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class EnemyDeathEffect: IEnemyEffect
    {
        private readonly AnimatedSprite Sprite;
        private int CreatedInRoom;
        public EnemyDeathEffect(Vector2 position)
        {
            Sprite = SpriteFactory.getInstance().CreateEnemyDeathSprite();
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyDie);
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

