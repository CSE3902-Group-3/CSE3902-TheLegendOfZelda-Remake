using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class LinkCollisionWithEnemy
    {

        private static float cooldown = Link.getInstance().damageCooldownTimer; // Set the cooldown (in seconds) for damage

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
