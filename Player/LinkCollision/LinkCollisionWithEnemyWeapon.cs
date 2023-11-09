using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemyWeapon
    {
        private static float cooldown = Link.getInstance().damageCooldownTimer; // Set the cooldown (in seconds) for damage

        public static void HandleCollisionWithEnemyWeapon(CollisionInfo collision)
        {
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
                Link.getInstance().TakeDamage(damage);

                Link.getInstance().damageCooldownTimer = Link.getInstance().damageCooldownDuration;
            }

            Link.getInstance().stateMachine.ChangeState(new KnockBackLinkState());
        }
    }
}
