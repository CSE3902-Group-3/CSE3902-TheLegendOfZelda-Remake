﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public interface IEnemy: IUpdateable, ICollidable
    {
        Vector2 Position { get; }
        bool Frozen { get; set; }
        void Spawn();
        void Despawn();
        void UpdateHealth(float damagePoints);
        void Stun();
        void Attack();
        void ChangePosition();
        void ChangeDirection();
        void Die();
        void DropItem();
    }
}
