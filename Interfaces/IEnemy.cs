using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public interface IEnemy: IUpdateable, ICollidable
    {
        AnimatedSprite Sprite { get; set; }
        float Health { get; set; }
        int Width { get; }
        int Height { get; }
        Type EnemyType { get; set; }
        EnemyItemDrop.EnemyClass Classification { get; }
        Vector2 Position { get; set; }
        Vector2 Direction { get; set; }
        Vector2 Offset { get; set; }
        RectCollider Collider { get; }
        bool IsColliding { get; set; }
        bool Frozen { get; set; }
        bool AllowedToMove { get; set; }
        Vector2 SpeedMultiplier { get; set; }
        float CurrentCooldown { get; set; }
        double LastSwitch { get; set; }

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
