﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class SpikeTrap : IEnemy
    {
        public AnimatedSprite Sprite { get; set; }
        public float Health { get; set; } = 2.0f;
        public int Width { get; } = 16;
        public int Height { get; } = 16;
        public Type EnemyType { get; set; }
        public EnemyItemDrop.EnemyClass Classification { get; } = EnemyItemDrop.EnemyClass.C;
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; } = new(0, 0);
        public Vector2 Offset { get; set; } = new(0, 0);
        public RectCollider Collider { get; }
        public bool IsColliding { get; set; } = false;
        public bool Frozen { get; set; } = false;
        public bool AllowedToMove { get; set; } = true;
        public Vector2 SpeedMultiplier { get; set; } = new(1, 1);
        public float CurrentCooldown { get; set; } = 0.0f;
        public double LastSwitch { get; set; } = 0;
        public Vector2 OriginalPosition;
        private readonly float interpolationSpeed = 0.05f; // Adjust this value to control the speed of interpolation
        private readonly float detectionCooldown = 2.0f; // Cooldown before re-detecting the player
        private float currentDetectionCooldown = 0.0f;
        public SpikeTrap(Vector2 pos)
        {
            Position = pos;
            OriginalPosition = pos;
            Sprite = SpriteFactory.getInstance().CreateBladeTrapSprite();
            Sprite.UnregisterSprite();
            LevelManager.AddUpdateable(this);
            Sprite.UpdatePos(pos);
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, Width * scale, Height * scale),
               CollisionLayer.Enemy,
               this
           );

            currentDetectionCooldown = detectionCooldown;
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            Sprite.RegisterSprite();
        }
        public void Despawn()
        {
            Sprite.UnregisterSprite();
        }
        public void Die()
        {
            Sprite.UnregisterSprite();
            Collider.Active = false;
            LevelManager.RemoveUpdateable(this);
            new EnemyDeathEffect(Position);
            LevelManager.CurrentLevelRoom.RemoveEnemy(this);
        }
        public void UpdateHealth(float damagePoints) { }

        public void Attack() {
            Vector2 linkPosition = GameState.Link.Pos;
            // Calculate the direction to the player dynamically
            Direction = linkPosition - Position;
            Direction.Normalize(); // Ensure the direction is a unit vector
            ChangePosition();
        }

        public void ChangePosition() {
            if (!Frozen)
            {
                Position += Direction * 3;
                Sprite.UpdatePos(Position);
                Collider.Pos = Position;
            }
        }

        public void ChangeDirection() { }
        public void Update(GameTime gameTime)
        {
            Vector2 linkPosition = GameState.Link.Pos;
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;

            if (currentDetectionCooldown > 0.0f)
            {
                currentDetectionCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Check if the player is in line with the trap
            if ((linkPosition.X == Position.X && linkPosition.Y >= Position.Y - Height) ||
                (linkPosition.X == Position.X && linkPosition.Y <= Position.Y + Height) ||
                (linkPosition.Y == Position.Y && linkPosition.X >= Position.X - Width) ||
                (linkPosition.Y == Position.Y && linkPosition.X <= Position.X + Width))
            {
                if (currentDetectionCooldown <= 0.0f)
                {
                    Attack();
                } else
                {
                    ResetPosition();
                }
            }
            else // Player is not in line with the trap
            {
                ResetPosition();
            }
        }

       public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    EnemyUtilities.HandleWeaponCollision(this, GetType(), collision);
                }
                if (collidedWith == CollisionLayer.OuterWall || collidedWith == CollisionLayer.Wall)
                {
                    Direction = new Vector2(0, 0);
                }
                if (collidedWith == CollisionLayer.Player)
                {
                    Sprite.UpdatePos(Position);
                    Collider.Pos = Position;
                    currentDetectionCooldown = detectionCooldown;
                    ResetPosition();
                }
            }
        }
        public void Stun() { }
        public void DropItem() { }
        private void ResetPosition()
        {
            // Check if the spike trap is already close to the original position
            float distanceToOriginal = Vector2.Distance(Position, OriginalPosition);

            // If the spike trap is close enough, directly set the position to the original position
            if (distanceToOriginal > 0.01f)
            {
                Position = OriginalPosition;
            }
            else
            {
                // Use lerp to smoothly interpolate between the current position and the original position
                Position = Vector2.Lerp(Position, OriginalPosition, interpolationSpeed);
            }

            // Update the sprite and collider positions
            Sprite.UpdatePos(Position);
            Collider.Pos = Position;
        }
    }
}
