using System.Collections.Generic;
using System;

namespace LegendOfZelda
{
    public class EnemyUtilities
    {
        public static readonly float DAMAGE_COOLDOWN = 1.0f; // Adjust the delay duration as needed
        public static void HandleWeaponCollision(IEnemy enemy, Type enemyType, CollisionInfo collision)
        {
            ICollidable projectileCollidedWith = collision.CollidedWith.Collidable;

            Dictionary<Type, float> damageMap = new()
            {
                { typeof(BoomerangProjectile), 0.5f }, // Hurts only minor enemies, stuns all others
                { typeof(Sword), 1.0f },
                { typeof(ArrowProjectile), 1.0f },
                { typeof(BlueArrowProjectile), 1.0f },
                { typeof(Explosion), 4.0f },
                { typeof(SwordBeam), 1.0f },
                { typeof(SwordBeamBurstProjectile), 1.0f },
                { typeof(FireProjectile), 1.0f },
            };

            List<Type> stunnableEnemies = new()
            {
                { typeof(Goriya) },
                { typeof(Rope) },
                { typeof(Skeleton) },
            };

            List<Type> noBoomerangEffect = new()
            {
                { typeof(Aquamentus) },
                { typeof(Dodongo) },
                { typeof(WallMaster) },
                { typeof(ZolBig) },
            };

            Type weaponType = projectileCollidedWith.GetType();
            float damage = damageMap[weaponType];

            if (damageMap.ContainsKey(weaponType))
            {
                /*
                * Handle different enemy collisions with boomerang
                * Stun: Goriya, Rope, Skeleton
                * Damage: Bat, Gel Small
                * No Effect: Aquamentus, Dodongo, Wallmaster, Zol Big
                */
                if (weaponType == typeof(BoomerangProjectile) && stunnableEnemies.Contains(enemyType))
                {
                    enemy.Stun();
                }
                else if (!(weaponType == typeof(BoomerangProjectile)) && !noBoomerangEffect.Contains(enemyType))
                {
                    enemy.UpdateHealth(damage);
                }
            }
        }
    }
}
