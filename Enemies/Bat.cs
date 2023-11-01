using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bat : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private float Health { get; set; } = 0.5f;
        public Vector2 Position;
        public Vector2 Offset = new Vector2(0, 16);
        public RectCollider Collider { get; private set; }
        public Bat(Vector2 pos)
        {
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y + (int)Offset.Y, 16 * scale, 10 * scale),
               CollisionLayer.Enemy,
               this
           );
            StateMachine = new SimpleEnemyStateMachine(Position, Offset, Collider)
            {
                Sprite = SpriteFactory.getInstance().CreateKeeseSprite(),
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
        public void UpdateHealth(float damagePoints)
        {
            StateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            StateMachine.ChangeDirection();
            Collider.Pos = Position + Offset;
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
