using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class Wizard : IEnemy
    {
        private readonly Game1 Game;
        private readonly SimpleEnemyStateMachine StateMachine;
        private int Health { get; set; } = 1;
        public Vector2 Position;

        public Wizard(Vector2 pos)
        {
            Game = Game1.instance;
            Position = pos;
            StateMachine = new SimpleEnemyStateMachine(pos)
            {
                Sprite = Game.spriteFactory.CreateOldManSprite(),
                Health = Health
            };
        }
        public void Spawn()
        {
            StateMachine.Spawn();
        }
        public void ChangePosition() {}
        public void Attack()
        {
            StateMachine.Attack();
        }
        public void UpdateHealth(int damagePoints)
        {
            StateMachine.UpdateHealth(damagePoints);
        }

        public void ChangeDirection() {}
        public void Die()
        {
            StateMachine.Die();
        }

        public void Update(GameTime gameTime) {}
    }
}
