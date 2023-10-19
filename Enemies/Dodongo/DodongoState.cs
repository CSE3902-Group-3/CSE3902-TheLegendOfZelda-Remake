using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public class DodongoState : IEnemy
    {
        public IEnemy State { get;  set; }
        private double LastDirSwitch = 0;
        private double LastHealthSwitch = 0;

        public DodongoState(Vector2 pos)
        {
            State = new RightMovingDodongo(this, pos);
        }
        public void Spawn()
        {
            LevelMaster.RegisterUpdateable(this);
            State.Spawn();
        }
        public void ChangePosition()
        {
            State.ChangePosition();
        }
        public void Attack()
        {
            State.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            State.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            State.ChangeDirection();
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > LastDirSwitch + 2000)
            {
                LastDirSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                State.ChangeDirection();
            }
            if (gameTime.TotalGameTime.TotalMilliseconds > LastHealthSwitch + 333)
            {
                LastHealthSwitch = gameTime.TotalGameTime.TotalMilliseconds;
                State.UpdateHealth(0); // Passing 0 since nothing in this method handles actual damage points yet
            }
            State.ChangePosition();
        }
        public void Die()
        {
            State.Die();
        }

        public void OnCollision(List<CollisionInfo> collisions)
        {
            foreach (CollisionInfo collision in collisions)
            {
                CollisionLayer collidedWith = collision.CollidedWith.Layer;

                if (collidedWith == CollisionLayer.OuterWall)
                {
                    ChangeDirection();
                }
                else if (collidedWith == CollisionLayer.PlayerWeapon)
                {
                    UpdateHealth(1); // Choose different values for each type of player weapon
                }
            }
        }
    }
}