using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class ZolBig : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private float Health { get; set; } = 2.0f;
        public Vector2 Position;
        public Vector2 Offset = new Vector2(0, 0);
        public RectCollider Collider { get; private set; }
        public ZolBig(Vector2 pos)
        {
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;

            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y, 16 * scale, 16 * scale),
               CollisionLayer.Enemy,
               this
           );
            AnimatedSprite sprite = SpriteFactory.getInstance().CreateZolSprite();
            sprite.UnregisterSprite();
            StateMachine = new SimpleEnemyStateMachine(Position, Offset, Collider)
            {
                Sprite = sprite,
                Health = Health,
                EnemyType = GetType(),
                Classification = EnemyItemDrop.EnemyClass.C,
                Width = 16,
                Height = 16,
            };
        }
        public void Spawn()
        {
            StateMachine.Spawn();
        }
        public void Despawn()
        {
            StateMachine.Despawn();
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
        public void Stun() { }
        public void DropItem()
        {
            StateMachine.DropItem();
        }
    }
}
