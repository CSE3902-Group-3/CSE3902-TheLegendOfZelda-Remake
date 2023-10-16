using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class WallMaster : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;

        public WallMaster(Vector2 pos)
        {
            Position = pos;
            StateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = SpriteFactory.getInstance().CreateWallmasterSprite(),
                Health = Health,
                IsFlying = false
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

        public void OnCollision(List<CollisionInfo> collisions)
        {
            StateMachine.OnCollision(collisions);
        }
    }
}
