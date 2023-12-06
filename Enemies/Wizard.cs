using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        public int Width { get; set; } = 18;
        public int Height { get; set; } = 18;
        public AnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float CurrentCooldown { get; set; } = 0.0f;
        public RectCollider Collider { get; }

        public bool Frozen { get; set; } = true;
        public float Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type EnemyType { get; set ; }

        public EnemyItemDrop.EnemyClass Classification => throw new NotImplementedException();

        public Vector2 Direction { get; set; } = new(0, 0);
        public Vector2 Offset { get; set; } = new(0, 0);
        public bool IsColliding { get; set; } = false;
        public bool AllowedToMove { get; set; } = false;
        public Vector2 SpeedMultiplier { get; set; } = new(0, 0);
        public double LastSwitch { get; set; } = 0.0f;

        public Wizard(Vector2 pos)
        {
            Position = pos;
            Sprite = SpriteFactory.getInstance().CreateOldManSprite();
            Sprite.UpdatePos(pos);
            Sprite.UnregisterSprite();
            LevelManager.AddUpdateable(this);
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, Width * scale, Height * scale),
               CollisionLayer.Enemy,
               this
           );
        }
        public void Spawn()
        {
            EnemyStateMachine.Spawn(this);
        }
        public void Despawn()
        {
            EnemyStateMachine.Despawn(this);
        }
        public void Attack()
        {
            // Mechanics of this attack can be changed later
            new FireProjectile(Position, LegendOfZelda.Direction.right);
        }
        public void UpdateHealth(float damagePoints)
        {
            EnemyStateMachine.UpdateHealth(this, damagePoints);
        }
        public void Update(GameTime gameTime)
        {
            CurrentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds; // Decrement the cooldown timer
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;
                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (CurrentCooldown <= 0)
                    {
                        CurrentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                    }
                }
            }
        }

        public void Stun() { }

        public void ChangePosition() { }

        public void ChangeDirection() { }

        public void Die() { }

        public void DropItem() { }
    }
}
