﻿namespace LegendOfZelda
{
    public interface IEnemy: IUpdateable, ICollidable
    {
        void Spawn();
        void UpdateHealth(float damagePoints);
        void Stun();
        void Attack();
        void ChangePosition();
        void ChangeDirection();
        void Die();
        void DropItem();
    }
}
