﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bat : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        public RectCollider Collider { get; private set; }
        public Bat(Vector2 pos)
        {
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)this.Position.X, (int)+this.Position.Y, 8 * scale, 8 * scale),
               CollisionLayer.Enemy,
               this
           );
            StateMachine = new SimpleEnemyStateMachine(pos, Collider)
            {
                Sprite = SpriteFactory.getInstance().CreateKeeseSprite(),
                Health = Health,
            };
        }
        public void Spawn()
        {
            new EnemySpawnEffect(Position);
            StateMachine.Spawn();
        }
        public void ChangePosition()
        {
            StateMachine.ChangePosition();
        }
        public void Attack()
        {
            StateMachine.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            StateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            StateMachine.ChangeDirection();
            Collider.Pos = Position;
        }
        public void Die()
        {
            StateMachine.Die();
            new EnemyDeathEffect(Position);
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            StateMachine.OnCollision(collisions);
        }
    }
}
