using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static LegendOfZelda.EnemyItemDrop;

namespace LegendOfZelda
{
    public static class EnemyStateMachine
    {
        public static void ChangeDirection(IEnemy enemy)
        {
            Random rand = new();
            int random = rand.Next(0, 4);

            if (random == 0)
            {
                enemy.Direction = new Vector2(1, 0);
            }
            else if (random == 1)
            {
                enemy.Direction = new Vector2(-1, 0);
            }
            else if (random == 2)
            {
                enemy.Direction = new Vector2(0, 1);
            }
            else if (random == 3)
            {
                enemy.Direction = new Vector2(0, -1);
            }
        }

        public static void ChangePosition(IEnemy enemy)
        {
            if (!enemy.Frozen && enemy.AllowedToMove)
            {
                enemy.Position += enemy.Direction * enemy.SpeedMultiplier;
                enemy.Sprite.UpdatePos(enemy.Position);
                enemy.Collider.Pos = enemy.Position + enemy.Offset;
            }
        }
        public static void Spawn(IEnemy enemy)
        {
            new EnemySpawnEffect(enemy.Position);
            enemy.Sprite.RegisterSprite();
            enemy.Sprite.UpdatePos(enemy.Position);
        }
        public static void Despawn(IEnemy enemy)
        {
            enemy.Sprite.UnregisterSprite();
        }
        public static void Die(IEnemy enemy)
        {
            enemy.Sprite.UnregisterSprite();
            enemy.Collider.Active = false;
            LevelManager.RemoveUpdateable(enemy);
            new EnemyDeathEffect(enemy.Position);
            DropItem(enemy);
            LevelManager.CurrentLevelRoom.RemoveEnemy(enemy);
        }
        public static void Update(IEnemy enemy, GameTime gameTime)
        {
            enemy.CurrentCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (gameTime.TotalGameTime.TotalMilliseconds > enemy.LastSwitch + 1000 && enemy.IsColliding == false)
            {
                enemy.LastSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                ChangeDirection(enemy);
            }
            ChangePosition(enemy);
            enemy.Sprite.UpdatePos(enemy.Position);
            enemy.Collider.Pos = enemy.Position + enemy.Offset;
        }

        public static void UpdateHealth(IEnemy enemy, float damagePoints)
        {
            enemy.Health -= damagePoints;

            // Indicate damage, or if health has reached 0, die
            if (enemy.Health < 0)
            {
                Die(enemy);
            }
            else
            {
                SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
            }
        }

        public static void OnCollision(IEnemy enemy, List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall || (enemy.EnemyType != typeof(Bat) && collidedWith == CollisionLayer.Wall)) // Bat should be able to float over inner walls
                {
                    enemy.IsColliding = true;
                    enemy.Direction *= -1;
                    enemy.Sprite.UpdatePos(enemy.Position);
                    enemy.Collider.Pos = enemy.Position + enemy.Offset;
                    ChangePosition(enemy);
                    enemy.IsColliding = false;
                    ChangeDirection(enemy);
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    if (enemy.CurrentCooldown <= 0)
                    {
                        EnemyUtilities.HandleWeaponCollision(enemy, enemy.EnemyType, collision);
                        enemy.CurrentCooldown = EnemyUtilities.DAMAGE_COOLDOWN; // Reset the cooldown timer
                        enemy.Sprite.flashing = true;
                        new Timer(1.0f, () => StopFlashing(enemy));
                    }
                }
            }
        }
        public static void Stun(IEnemy enemy)
        {
            enemy.AllowedToMove = false;
            SoundFactory.PlaySound(SoundFactory.getInstance().EnemyHit);
            new Timer(2.0f, () => CompleteStun(enemy));
        }
        public static void CompleteStun(IEnemy enemy)
        {
            enemy.AllowedToMove = true;
        }
        public static void StopFlashing(IEnemy enemy)
        {
            enemy.Sprite.flashing = false;
        }
        public static void DropItem(IEnemy enemy)
        {
            Vector2 Center = EnemyUtilities.GetCenter(enemy.Position, enemy.Width, enemy.Height);

            switch (enemy.Classification)
            {
                case EnemyClass.A:
                    DropClassAItem(Center);
                    break;
                case EnemyClass.B:
                    DropClassBItem(Center);
                    break;
                case EnemyClass.C:
                    DropClassCItem(Center);
                    break;
                case EnemyClass.D:
                    DropClassBItem(Center);
                    break;
                default:
                    break;
            }
        }
    }
}
