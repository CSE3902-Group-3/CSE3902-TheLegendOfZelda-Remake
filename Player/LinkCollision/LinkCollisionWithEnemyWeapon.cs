using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class LinkCollisionWithEntity
    {
        public static void HandleCollisionWithEnemy(CollisionInfo collision)
        {
            IEnemy enemyCollidedWith = null;

            var enemyDamageMap = new Dictionary<Type, float>
            {
                { typeof(AquamentusBall), 0.5f },
                { typeof(GoriyaBoomerang), 0.5f },
                { typeof(FireProjectile), 1.0f }  // dodongo?
            };

            Type enemyType = enemyCollidedWith.GetType();
            if (enemyDamageMap.ContainsKey(enemyType))
            {
                float damage = enemyDamageMap[enemyType];
                ((Link)Game1.getInstance().link).TakeDamage(damage);
            }

            ((Link)Game1.getInstance().link).StopTakingDamage();
        }
    }
}
