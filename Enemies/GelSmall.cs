using LegendOfZelda.Enemies;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class GelSmall : IEnemy
    {
        private readonly Game1 game;
        private readonly SimpleEnemyStateMachine stateMachine;
        private int Health { get; set; } = 1;
        public Vector2 position;

        public GelSmall(Vector2 pos)
        {
            game = Game1.instance;
            position = pos;
            stateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = game.spriteFactory.CreateGelSprite(),
                Health = Health
            };
        }
        public void Spawn()
        {
            stateMachine.Spawn();
        }
        public void ChangePosition()
        {
            stateMachine.ChangePosition();
        }
        public void Attack()
        {
            stateMachine.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            stateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection()
        {
            stateMachine.ChangeDirection();
        }
        public void Die()
        {
            stateMachine.Die();
        }

        public void Update(GameTime gameTime)
        {
            stateMachine.Update(gameTime);
        }
    }
}
