using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemyWeapon
    {
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
            if (enemyDamageMap.ContainsKey(enemyType))
            {
                float damage = enemyDamageMap[enemyType];
                ((Link)Game1.getInstance().link).TakeDamage(damage);
            }

            ((Link)Game1.getInstance().link).StopTakingDamage();
        }
    }
}
