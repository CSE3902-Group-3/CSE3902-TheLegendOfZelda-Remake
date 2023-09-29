using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class DodongoState : IEnemy
    {
        private readonly Game1 game;
        public IEnemy State { get;  set; }
        private double LastDirSwitch = 0;
        private double LastHealthSwitch = 0;

        public DodongoState(Vector2 pos)
        {
            State = new RightMovingDodongo(this, pos);
            game = Game1.instance;
            Spawn();
        }
        public void Spawn()
        {
            game.RegisterUpdateable(this);
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
    }
}