using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class GelSmall : IEnemy
    {
        private readonly Game1 Game;
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;

        public GelSmall(Vector2 pos)
        {
            Game = Game1.instance;
            Position = pos;
            StateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = Game.spriteFactory.CreateGelSprite(),
                Health = Health
            };
        }
        public void Spawn()
        {
            StateMachine.Spawn();
        }
        public void ChangePosition()
        {
            StateMachine.ChangePosition();
        }
        public void Attack()
        {
            StateMachine.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            StateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            StateMachine.ChangeDirection();
        }
        public void Die()
        {
            StateMachine.Die();
        }

        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }
    }
}
