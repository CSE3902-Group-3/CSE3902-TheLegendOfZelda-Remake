using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemyWeapon
    {
        private static bool isTakingDamage = false; // Flag to track if Link is taking damage

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
            if (enemyDamageMap.ContainsKey(enemyType) && !isTakingDamage)
            {
                float damage = enemyDamageMap[enemyType];
                ((Link)Game1.getInstance().link).TakeDamage(damage);
                isTakingDamage = true; // Set the flag to true to indicate Link is taking damage
            }

            Link.getInstance().stateMachine.ChangeState(new KnockBackLinkState());
        }
    }
}
