using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bat : IEnemy
    {
        public AnimatedSprite Sprite { get; set; }
        public float Health { get; set; } = 0.5f;
        public int Width { get; }
        public int Height { get; }
        public Type EnemyType { get; set; }
        public EnemyItemDrop.EnemyClass Classification { get; } = EnemyItemDrop.EnemyClass.X;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new(0, 0);
        public Vector2 Offset { get; set; } = new(0, 16);
        public RectCollider Collider { get; }
        public bool IsColliding { get; set; } = false;
        public bool Frozen { get; set; } = false;

        public bool AllowedToMove { get; set; } = true;
        public Vector2 SpeedMultiplier { get; set; } = new(1, 1);
        public float CurrentCooldown { get; set; } = 0.0f;
        public double LastSwitch { get; set; } = 0;
        public Bat(Vector2 pos)
        {
            LevelManager.AddUpdateable(this);
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y + (int)Offset.Y, 16 * scale, 10 * scale),
               CollisionLayer.Enemy,
               this
           );
           Sprite = SpriteFactory.getInstance().CreateKeeseSprite();
           Sprite.UnregisterSprite();          
        }
        public void Spawn()
        {
            EnemyStateMachine.Spawn(this);
        }
        public void Despawn()
        {
            EnemyStateMachine.Despawn(this);
        }
        public void ChangePosition()
        {
            EnemyStateMachine.ChangePosition(this);
        }
        public void Attack() {}
        public void UpdateHealth(float damagePoints)
        {
            EnemyStateMachine.UpdateHealth(this, damagePoints);
        }

        public void ChangeDirection()
        {
            EnemyStateMachine.ChangeDirection(this);
            Collider.Pos = Position + Offset;
        }
        public void Die()
        {
            EnemyStateMachine.Die(this);
        }

        public void Update(GameTime gameTime)
        {
            EnemyStateMachine.Update(this, gameTime);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            EnemyStateMachine.OnCollision(this, collisions);
        }
        public void Stun()
        {
            EnemyStateMachine.Stun(this);
        }
        public void DropItem() { }
    }
}
