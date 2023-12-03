using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class Bat : IEnemy
    {
        private readonly SimpleEnemyStateMachine StateMachine;
        private float Health { get; set; } = 0.5f;
        public Vector2 Position { get; set; }
        public Vector2 Offset = new(0, 16);
        public RectCollider Collider { get; private set; }
        private bool isFrozen = false;
        public bool Frozen { get { return isFrozen; } set { isFrozen = value; } }
        public Bat(Vector2 pos)
        {
            Position = pos;
            int scale = SpriteFactory.getInstance().scale;
            Collider = new RectCollider(
               new Rectangle((int)Position.X, (int)Position.Y + (int)Offset.Y, 16 * scale, 10 * scale),
               CollisionLayer.Enemy,
               this
           );
           AnimatedSprite sprite = SpriteFactory.getInstance().CreateKeeseSprite();
           sprite.UnregisterSprite();
           StateMachine = new SimpleEnemyStateMachine(Position, Offset, Collider, this)
           {
               Sprite = sprite,
               Health = Health,
               EnemyType = GetType(),
               Classification = EnemyItemDrop.EnemyClass.X
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
        public void Stun()
        {
            StateMachine.Stun();
        }
        public void DropItem() { }
    }
}
