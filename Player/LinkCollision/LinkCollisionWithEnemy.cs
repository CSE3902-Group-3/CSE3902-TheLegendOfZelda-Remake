using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemy
    {

        private static bool isTakingDamage = false; // Flag to track if Link is taking damage

        public static void HandleCollisionWithEnemy(CollisionInfo collision)
        {
            IEnemy enemyCollidedWith = collision.CollidedWith.Collidable as IEnemy;

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
