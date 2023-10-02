﻿using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Bat : IEnemy
    {
        private readonly Game1 Game;
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        public Bat(Vector2 pos)
        {
            game = Game1.getInstance();
            Position = pos;
            StateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = Game.spriteFactory.CreateKeeseSprite(),
                Health = Health,
            };
        }
        public void Spawn()
        {
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
        }
        public void Die()
        {
            StateMachine.Die();
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }
    }
}
