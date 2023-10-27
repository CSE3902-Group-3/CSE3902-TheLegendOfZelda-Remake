using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class WallMaster : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;
        public Vector2 Offset = new Vector2(0, 0);
        public RectCollider Collider { get; private set; }
        public WallMaster(Vector2 pos)
        {
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
            StateMachine = new SimpleEnemyStateMachine(Position, Offset, Collider)
            {
                Sprite = SpriteFactory.getInstance().CreateWallmasterSprite(),
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
        }
        public void Die()
        {
            StateMachine.Die();
            Collider.Active = false;
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
        public void DropItem()
        {
            StateMachine.DropItem();
        }
    }
}
