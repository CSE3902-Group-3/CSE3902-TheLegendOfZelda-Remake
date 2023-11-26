using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemyWeapon
    {
        private static float cooldown = GameState.Link.damageCooldownTimer; // Set the cooldown (in seconds) for damage

        public static void HandleCollisionWithEnemyWeapon(CollisionInfo collision)
        {
            if (GameState.Link.StateMachine.CurrentState is KnockBackLinkState)
            {
                return;
            }

            IEnemyProjectile enemyProjectileCollidedWith = collision.CollidedWith.Collidable as IEnemyProjectile;

            var enemyDamageMap = new Dictionary<Type, float>
            {
                { typeof(AquamentusBall), 0.5f },
                { typeof(GoriyaBoomerang), 0.5f },
                { typeof(FireProjectile), 1.0f }  // dodongo?
            };

            Type enemyType = enemyProjectileCollidedWith.GetType();
            if (enemyDamageMap.ContainsKey(enemyType) && cooldown <= 0)
            {
                float damage = enemyDamageMap[enemyType];
                GameState.Link.TakeDamage(damage);

                GameState.Link.damageCooldownTimer = GameState.Link.damageCooldownDuration;
            }

            if (GameState.Link.StateMachine.CurrentState is not DeathLinkState)
                GameState.Link.StateMachine.ChangeState(new KnockBackLinkState());
        }
    }
}
