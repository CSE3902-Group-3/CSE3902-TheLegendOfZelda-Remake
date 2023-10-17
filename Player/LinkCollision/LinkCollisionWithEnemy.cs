using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemy
    {
        public static void HandleCollisionWithEnemy(CollisionInfo collision)
        {
            IEnemy enemyCollidedWith = null;

            var enemyDamageMap = new Dictionary<Type, float>
            {
                { typeof(Aquamentus), 0.5f },
                { typeof(Bat), 0.5f },
                { typeof(Goriya), 1.0f },
                { typeof(GelSmall), 0.5f },
                { typeof(Rope), 0.5f },
                { typeof(Skeleton), 0.5f },
                { typeof(BladeTrap), 0.25f }
            };

            Type enemyType = enemyCollidedWith.GetType();
            if (enemyDamageMap.ContainsKey(enemyType))
            {
                float damage = enemyDamageMap[enemyType];
                ((Link)Game1.getInstance().link).TakeDamage(damage);
            }
            // bat half heart damage
            // Aquamentus half heart damage (fireball 1/2)
            // Goriya 1 heart (boomerang 1)
            // Dodongo fire 1 heart / tail 1/2 heart
            // gel 1/2 heart
            // rope half heart
            // stalfos 1/2 heart
            // blade trap 1/4 heart
            ((Link)Game1.getInstance().link).StopTakingDamage();
        }
    }
}
